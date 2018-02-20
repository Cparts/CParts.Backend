using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Services.Abstractions.Parts
{
    public interface IApplicabilityServiceMapper
    {
        Task<ICollection<ApplicableManufacturerViewModel>> GetManufacturersWithApplicableModels(int articleId, int langId = 4);
        Task<ICollection<ApplicableModelViewModel>> GetModelsWithApplicableTypes(int articleId, int manufacturerId, int langId = 4);
        Task<ICollection<ApplicableTypeViewModel>> GetApplicableTypesByModel(int articleId, int modelId, int langId = 4);
    }
}