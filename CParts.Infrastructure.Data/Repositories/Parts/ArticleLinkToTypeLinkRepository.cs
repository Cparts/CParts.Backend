using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ArticleLinkToTypeLinkRepository : ReadRepositoryBase<ArticleLinkToTypeLink, IPartsDataDbContext>,
        IArticleLinkToTypeLinkRepository
    {
        public ArticleLinkToTypeLinkRepository(IPartsDataDbContext context) : base(context)
        {
        }
    }
}