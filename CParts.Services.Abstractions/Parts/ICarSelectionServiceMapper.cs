using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Services.Abstractions.Parts
{
    public interface ICarSelectionServiceMapper
    {
        Task<ICollection<Manufacturer>> GetAllManufacturerAsync();
        Task<ICollection<ModelViewModel>> GetModelsByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4);
        Task<ICollection<Type>> GetTypesByModelAsync(int modelId, int languageId = 4);

    }
}