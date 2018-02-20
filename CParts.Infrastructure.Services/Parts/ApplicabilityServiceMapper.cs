using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Services.Abstractions.Parts;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Infrastructure.Services.Parts
{
    public class ApplicabilityServiceMapper : IApplicabilityServiceMapper
    {
        private readonly IPartApplicabilityService _partApplicabilityService;

        public ApplicabilityServiceMapper(IPartApplicabilityService partApplicabilityService)
        {
            _partApplicabilityService = partApplicabilityService;
        }

        public async Task<ICollection<ApplicableManufacturerViewModel>> GetManufacturersWithApplicableModels(
            int articleId, int langId = 4)
        {
            var rawManufacturers = await _partApplicabilityService.GetManufacturersWithApplicableModels(articleId, langId);

            var models = rawManufacturers.Select(x => new ApplicableManufacturerViewModel
            {
                Id = x.Id,
                Name = x.Brand
            }).ToList();

            return models;
        }

        public async Task<ICollection<ApplicableModelViewModel>> GetModelsWithApplicableTypes(int articleId,
            int manufacturerId, int langId = 4)
        {
            var rawModels =
                await _partApplicabilityService.GetModelsWithApplicableTypesByManufactuer(articleId, manufacturerId,
                    langId);

            var models = rawModels.Select(x => new ApplicableModelViewModel
            {
                Id = x.Id,
                Description = x.CountryDesignation?.Text.Text
            }).ToList();

            return models;
        }

        public async Task<ICollection<ApplicableTypeViewModel>> GetApplicableTypesByModel(int articleId, int modelId,
            int langId = 4)
        {
            var rawTypes = await _partApplicabilityService.GetApplicableTypesByModel(articleId, modelId, langId);

            var models = rawTypes.Select(x => new ApplicableTypeViewModel
            {
                Id = x.Id,
                Description = x.CountryDesignation?.Text.Text
            }).ToList();

            return models;
        }
    }
}