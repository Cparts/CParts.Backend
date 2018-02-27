using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.QueryModels;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public interface IEnginesRepository
    {
        Task<Engine> GetByTypeIdAsync(int typeId);
        Task<IEnumerable<TypeEngineQueryModel>> GetByTypeIdAsync(IEnumerable<int> typeIds);
    }
}