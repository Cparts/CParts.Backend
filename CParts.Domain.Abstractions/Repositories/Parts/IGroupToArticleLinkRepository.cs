using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts.Links;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IGroupToArticleLinkRepository : IReadRepository<LinkArt>
    {
        Task<ICollection<LinkArt>> GetByTypeAndSearchNode(int typeId, int searchNodeId);
    }
}