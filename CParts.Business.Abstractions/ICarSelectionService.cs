using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Business.Abstractions
{
    public interface ICarSelectionService
    {
        Task<ICollection<Manufacturer>> GetManufacturersAsync();
        Task<ICollection<Model>> GetByManufacturerAsync(int manufacturerId, int languageId);
        Task<ICollection<Type>> GetByModelAsync(int modelId, int languageId);
    }
}