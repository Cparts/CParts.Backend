using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Business.Abstractions.Parts
{
    public interface ISearchTreeService
    {
        Task<ICollection<SearchTree>> GetAppliableNodesAsync(int typeId, int? parentNode = null);
    }
}