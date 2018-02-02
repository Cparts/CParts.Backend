using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model;

namespace CParts.Services.Abstractions
{
    public interface IBrandsService
    {
        Task<ICollection<Brand>> AllAsync();
    }
}