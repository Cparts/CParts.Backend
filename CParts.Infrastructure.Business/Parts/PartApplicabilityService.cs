using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Parts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Infrastructure.Business.Parts
{
    public class PartApplicabilityService : IPartApplicabilityService
    {
        private readonly ITypesRepository _typesRepository;
        private readonly ICountryDesignationsRepository _countryDesignationsRepository;

        public PartApplicabilityService(ITypesRepository typesRepository,
            ICountryDesignationsRepository countryDesignationsRepository)
        {
            _typesRepository = typesRepository;
            _countryDesignationsRepository = countryDesignationsRepository;
        }

        public async Task<ICollection<Manufacturer>> GetManufacturersWithApplicableModels(int articleId, int langId = 4)
        {
            return await _typesRepository.GetPartApplicabilityMfsAsync(articleId);
        }

        public async Task<ICollection<Model>> GetModelsWithApplicableTypesByManufactuer(int articleId,
            int manufacturerId, int langId = 4)
        {
            var models = await _typesRepository.GetPartApplicabilityMdlsAsync(articleId, manufacturerId);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(models, langId);
            return models;
        }

        public async Task<ICollection<Type>> GetApplicableTypesByModel(int articleId, int modelId, int langId = 4)
        {
            var types = await _typesRepository.GetPartApplicabilityTypesAsync(articleId, modelId);
            await _countryDesignationsRepository.AppendDesignationsToCollectionAsync(types, langId);
            return types;
        }
    }
}