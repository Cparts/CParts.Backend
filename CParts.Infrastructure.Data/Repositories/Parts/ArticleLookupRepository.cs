using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Framework;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ArticleLookupRepository : ReadRepositoryBase<ArticleLookup, IPartsDataDbContext>,
        IArticleLookupRepository
    {
        public ArticleLookupRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<ICollection<ArticleLookup>> FindOriginalsForAritclesRange(IEnumerable<int> articleIds)
        {
            var artLookup = Context.Set<ArticleLookup>();

            var result = await
                (from arl in artLookup
                    where articleIds.Contains(arl.ArticleId) && arl.KindConverted == 3
                    select arl)
                .Include(x => x.Brand)
                .Include(x => x.Article)
                .AsNoTracking()
                .DistinctBy(x => x.CatalogueCode)
                .ToListAsync();

            return result;
        }
    }
}