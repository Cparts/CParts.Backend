using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Models;
using CParts.Business.Abstractions.Parts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Framework;
using CParts.Infrastructure.Data.Repositories.Parts;

namespace CParts.Infrastructure.Business.Parts
{
    public class CarSelectionService : ICarSelectionService
    {
        private readonly IManufacturersRepository _manufacturersRepository;
        private readonly IModelsRepository _modelsRepository;
        private readonly ITypesRepository _typesRepository;
        private readonly IGeneralDesignationsRepository _generalDesignationsRepository;
        private readonly ICountryDesignationsRepository _countryDesignationsRepository;
        private readonly IEnginesRepository _enginesRepository; 

        public CarSelectionService(IManufacturersRepository manufacturersRepository, IModelsRepository modelsRepository,
            ITypesRepository typesRepository, IGeneralDesignationsRepository generalDesignationsRepository,
            ICountryDesignationsRepository countryDesignationsRepository, IEnginesRepository enginesRepository)
        {
            _manufacturersRepository = manufacturersRepository;
            _modelsRepository = modelsRepository;
            _typesRepository = typesRepository;
            _generalDesignationsRepository = generalDesignationsRepository;
            _countryDesignationsRepository = countryDesignationsRepository;
            _enginesRepository = enginesRepository;
        }

        public async Task<ICollection<Manufacturer>> GetManufacturersAsync()
        {
            var manufacturers = await _manufacturersRepository.AllAsync();
            return manufacturers;
        }

        //TODO: Rename and move common part to separate method
        public async Task<ManufacturerModelsBusinessModel> GetByManufacturerAndYearAsync(int manufacturerId, int yearBetween,
            int languageId = 4)
        {
            var manufacturer = (await _manufacturersRepository.GetSingleByIdAsync(manufacturerId));
            var models = await _modelsRepository.GetByManufacturerAndYearAsync(manufacturerId, yearBetween);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(models, languageId);
            return new ManufacturerModelsBusinessModel
            {
                Models = models,
                Manufacturer = manufacturer
            };
        }

        public async Task<PaginatedResult<Model>> GetByManufacturerAsync(int manufacturerId, int page = 1,
            int languageId = 4)
        {
            var models = await _modelsRepository.GetByManufacturerAsync(manufacturerId, page);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(models.PageContent, languageId);
            return models;
        }

        public async Task<ICollection<TypeEngineBusinessModel>> GetByModelAsync(int modelId, int languageId)
        {
            var types = (await _typesRepository.GetByModelAsync(modelId)).ToList();
            var engines = (await _enginesRepository.GetByTypeIdAsync(types.Select(y => y.Id))).ToList();
            var engineLinks = engines.Select(x => x.Engine).ToList();
            await _generalDesignationsRepository.AppendDesignationsToCollectionAsync(types, languageId);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(types, languageId);
            await _generalDesignationsRepository.AppendDesignationsToCollectionAsync(engineLinks, languageId);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(engineLinks, languageId);
            return types.Select(type => new TypeEngineBusinessModel
            {
                Type = type,
                Engine = engines.First(y => y.TypeId == type.Id).Engine
            }).ToList();
        }
    }
}