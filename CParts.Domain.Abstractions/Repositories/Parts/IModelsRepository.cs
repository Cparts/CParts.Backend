using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IModelsRepository : IReadRepository<Model>
    {
        Task<ICollection<Model>> GetByManufacturerAsync(int manufacturerId);
    }
}