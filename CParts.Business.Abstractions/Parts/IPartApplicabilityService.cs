using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Business.Abstractions.Parts
{
    public interface IPartApplicabilityService
    {
        Task<ICollection<Manufacturer>> GetManufacturersWithApplicableModels(int articleId, int langId = 4);
        Task<ICollection<Model>> GetModelsWithApplicableTypesByManufactuer(int articleId, int manufacturerId,
            int langId = 4);
        Task<ICollection<Type>> GetApplicableTypesByModel(int articleId, int modelId, int langId = 4);
    }
}