using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class GroupToTreeLinkRepository : ReadRepositoryBase<GroupToTreeLink, IPartsDataDbContext>,
        IGroupToTreeLinkRepository
    {
        public GroupToTreeLinkRepository(IPartsDataDbContext context) : base(context)
        {
        }
    }
}