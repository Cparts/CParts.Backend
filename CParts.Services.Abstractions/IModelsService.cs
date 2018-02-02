using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model;

namespace CParts.Services.Abstractions
{
    public interface IModelsService
    {
        Task<ICollection<Model>> GetAllAsync();
        Task<ICollection<Model>> GetByManufacturer(int manufacturerId);
        Task<ICollection<Model>> GetByManufacturerAndYear(int manufacturerId, int year);
    }
}