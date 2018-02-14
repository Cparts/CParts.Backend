using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Services.Abstractions
{
    public interface ICarSelectionServiceWrapper
    {
        Task<ICollection<Manufacturer>> GetAllManufacturerAsync();
        Task<ICollection<Model>> GetModelsByManufacturerAsync(int manufacturerId, int languageId = 4);
        Task<ICollection<Type>> GetTypesByModelAsync(int modelId, int languageId = 4);

    }
}