using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.ViewModels;

namespace CParts.Services.Abstractions
{
    public interface IApplicabilityServiceWrapper
    {
        Task<ICollection<ApplicableManufacturerViewModel>> GetManufacturersWithApplicableModels(int articleId, int langId = 4);
        Task<ICollection<ApplicableModelViewModel>> GetModelsWithApplicableTypes(int articleId, int manufacturerId, int langId = 4);
        Task<ICollection<ApplicableTypeViewModel>> GetApplicableTypesByModel(int articleId, int modelId, int langId = 4);
    }
}