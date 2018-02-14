using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface ISearchTreeRepository : IReadRepository<SearchTree>
    {
        Task<ICollection<SearchTree>> GetAppliableNodes(int typeId, int? parentNode = null);
    }
}