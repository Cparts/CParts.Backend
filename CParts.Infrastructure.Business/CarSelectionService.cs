using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Infrastructure.Business
{
    public class CarSelectionService : ICarSelectionService
    {
        private readonly IManufacturersRepository _manufacturersRepository;
        private readonly IModelsRepository _modelsRepository;
        private readonly ITypesRepository _typesRepository;
        private readonly IGeneralDesignationsRepository _generalDesignationsRepository;

        public CarSelectionService(IManufacturersRepository manufacturersRepository, IModelsRepository modelsRepository,
            ITypesRepository typesRepository, IGeneralDesignationsRepository generalDesignationsRepository)
        {
            _manufacturersRepository = manufacturersRepository;
            _modelsRepository = modelsRepository;
            _typesRepository = typesRepository;
            _generalDesignationsRepository = generalDesignationsRepository;
        }

        public async Task<ICollection<Manufacturer>> GetManufacturersAsync()
        {
            var manufacturers = await _manufacturersRepository.AllAsync();
            return manufacturers;
        }

        public async Task<ICollection<Model>> GetByManufacturerAsync(int manufacturerId, int languageId = 4)
        {
            var models = await _modelsRepository.GetByManufacturerAsync(manufacturerId);
            return models;
        }

        public async Task<ICollection<Type>> GetByModelAsync(int modelId, int languageId)
        {
            var types = await _typesRepository.GetByModelAsync(modelId);
            await _generalDesignationsRepository.AppendDesignationsToCollection(types, languageId);
            return types;
        }
    }
}