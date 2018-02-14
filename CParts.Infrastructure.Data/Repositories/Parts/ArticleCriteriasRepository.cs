using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ArticleCriteriasRepository : ReadRepositoryBase<ArticleCriteria, IPartsDataDbContext>,
        IArticleCriteriasRepository
    {
        public ArticleCriteriasRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<ICollection<ArticleCriteria>> GetByArticleId(int id)
        {
            /* SET @ART_ID = 1806202; /* 202-134 [METZGER] - Главный тормозной цилиндр * /
               SET @LNG_ID = 16; /* 1 - Немецкий язык; 16 - Русский язык * /
               
               SELECT ART_ARTICLE_NR, SUP_BRAND,	DES_TEXTS.TEX_TEXT AS ART_COMPLETE_TEXT,	DES_TEXTS2.TEX_TEXT AS ART_DES_TEXT,	DES_TEXTS3.TEX_TEXT AS ART_STATUS_TEXT
               FROM ARTICLES
               INNER JOIN DESIGNATIONS ON DESIGNATIONS.DES_ID = ART_COMPLETE_DES_ID AND DESIGNATIONS.DES_LNG_ID = @LNG_ID
               INNER JOIN DES_TEXTS ON DES_TEXTS.TEX_ID = DESIGNATIONS.DES_TEX_ID
               LEFT JOIN DESIGNATIONS AS DESIGNATIONS2 ON DESIGNATIONS2.DES_ID = ART_DES_ID AND DESIGNATIONS2.DES_LNG_ID = @LNG_ID
               LEFT JOIN DES_TEXTS AS DES_TEXTS2 ON DES_TEXTS2.TEX_ID = DESIGNATIONS2.DES_TEX_ID
               INNER JOIN SUPPLIERS ON SUP_ID = ART_SUP_ID
               INNER JOIN ART_COUNTRY_SPECIFICS ON ACS_ART_ID = ART_ID
               INNER JOIN DESIGNATIONS AS DESIGNATIONS3 ON DESIGNATIONS3.DES_ID = ACS_KV_STATUS_DES_ID AND DESIGNATIONS3.DES_LNG_ID = @LNG_ID
               INNER JOIN DES_TEXTS AS DES_TEXTS3 ON DES_TEXTS3.TEX_ID = DESIGNATIONS3.DES_TEX_ID
               WHERE ART_ID = @ART_ID;
            */

            var result = from criteria in DbSet
                where criteria.ArticleId == id
                select criteria;
            result = result.Include(x => x.Criteria).AsNoTracking();

            return await result.ToListAsync();
        }

        public async Task<ICollection<ArticleCriteria>> GetByArticleIds(IEnumerable<int> ids)
        {
            var result = from criteria in DbSet
                where ids.Contains(criteria.ArticleId)
                select criteria;
            
            result = result.Include(x => x.Criteria).AsNoTracking();

            return await result.ToListAsync();
        }
    }
}