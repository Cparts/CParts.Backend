using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model;

namespace CParts.Services.Abstractions
{
    public interface IManufacturersService
    {
        Task<ICollection<Manufacturer>> GetAll();
    }
}