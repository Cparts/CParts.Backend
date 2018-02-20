using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.QueryModels;
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

        /*
         *  SELECT ARL_KIND,IF (ART_LOOKUP.ARL_KIND = 2, SUPPLIERS.SUP_BRAND, BRANDS.BRA_BRAND) AS BRAND, ARL_DISPLAY_NR
            FROM ART_LOOKUP
            LEFT JOIN BRANDS ON BRA_ID = ARL_BRA_ID
            INNER JOIN ARTICLES ON ARTICLES.ART_ID = ART_LOOKUP.ARL_ART_ID
            INNER JOIN SUPPLIERS ON SUPPLIERS.SUP_ID = ARTICLES.ART_SUP_ID
            WHERE ARL_ART_ID = @ART_ID AND	ARL_KIND IN (2, 3, 4)
            ORDER BY ARL_KIND,	BRA_BRAND,	ARL_DISPLAY_NR
            LIMIT	100;
         */

        public async Task<ICollection<AnalogueQueryArtLookup>> FindAnaloguesForArticleAsync(int articleId)
        {
            var artLookup = Context.Set<ArticleLookup>();
            var articles = Context.Set<Article>();
            var suppliers = Context.Set<Supplier>();
            var brands = Context.Set<Brand>();


            var query = from arl in artLookup
                join brand in brands on arl.BrandId equals brand.Id into ljBrands
                from ljBrand in ljBrands.DefaultIfEmpty()
                join article in articles on arl.ArticleId equals article.Id
                join supplier in suppliers on article.SupplierId equals supplier.Id
                where arl.KindConverted >= 2 && 
                      arl.KindConverted <= 4 &&
                      arl.ArticleId == articleId
                select new AnalogueQueryArtLookup
                {
                    ArticleId = arl.ArticleId,
                    Kind = arl.KindConverted,
                    DisplayNumber = arl.DisplayNumber,
                    BrandId = ljBrand.Id,
                    Brand = ljBrand,
                    SupplierId = supplier.Id,
                    Supplier = supplier
                };

            query = query/*.Include(x => x.Brand).Include(x => x.Supplier)#1#.Take(10)*/.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}