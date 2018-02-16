using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.ViewModels;

namespace CParts.Services.Abstractions
{
    public interface ICarSelectionServiceWrapper
    {
        Task<ICollection<Manufacturer>> GetAllManufacturerAsync();
        Task<ICollection<ModelViewModel>> GetModelsByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4);
        Task<ICollection<Type>> GetTypesByModelAsync(int modelId, int languageId = 4);

    }
}