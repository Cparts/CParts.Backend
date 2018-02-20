using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class GroupToArticleLinkRepository : ReadRepositoryBase<LinkArt, IPartsDataDbContext>,
        IGroupToArticleLinkRepository
    {
        public GroupToArticleLinkRepository(IPartsDataDbContext context) : base(context)
        {
        }

        /*
         * SET @TYP_ID = 3822; /* ALFA ROMEO 145 (930) 1.4 i.e. [1994/07-1996/12] * /
           SET @STR_ID = 10630; /* Поршень в сборе; Можете использовать NULL для вывода ВСЕХ запчастей к автомобилю * /
   
           SELECT	LA_ART_ID
           FROM LINK_GA_STR
           INNER JOIN LINK_LA_TYP ON LAT_TYP_ID = @TYP_ID AND	LAT_GA_ID = LGS_GA_ID
           INNER JOIN LINK_ART ON LA_ID = LAT_LA_ID
           WHERE LGS_STR_ID <=> @STR_ID
           ORDER BY LA_ART_ID
           LIMIT	100;
         */
        
        public async Task<ICollection<LinkArt>> GetByTypeAndSearchNode(int typeId, int searchNodeId)
        {
            var groupToTreeLinkSet = Context.Set<GroupToTreeLink>();
            var typeToArticleLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var groupToArticleLinkSet = Context.Set<LinkArt>();

            var query = (from groupTreeLink in groupToTreeLinkSet
                join typeArticleLink in typeToArticleLinkSet on
                    new {typeId = typeId, gaId = groupTreeLink.GaId}
                    equals
                    new {typeId = typeArticleLink.TypeId, gaId = typeArticleLink.LatGaId}
                join groupArticleLink in groupToArticleLinkSet on
                    typeArticleLink.LinkArtId
                    equals
                    groupArticleLink.Id
                where groupTreeLink.SearchTreeId == searchNodeId
                select groupArticleLink);

            query = query.Include(x => x.Article).ThenInclude(x => x.Supplier).AsNoTracking();
            return await query.ToListAsync();
        }
    }
}