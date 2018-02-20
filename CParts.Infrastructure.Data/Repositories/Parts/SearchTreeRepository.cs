using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class SearchTreeRepository : ReadRepositoryBase<SearchTree, IPartsDataDbContext>, ISearchTreeRepository
    {
        public SearchTreeRepository(IPartsDataDbContext context) : base(context)
        {
        }

        /* SET @TYP_ID = 3822; /* ALFA ROMEO 145 (930) 1.4 i.e. [1994/07-1996/12] * /
            SET @LNG_ID = 16; /* 1 - Немецкий язык; 16 - Русский язык * /
            SET @STR_ID = NULL; /* Корень дерева * /
            
            SELECT STR_ID, 
                TEX_TEXT AS STR_DES_TEXT, 
                IF( EXISTS( 
                    SELECT * 
                    FROM SEARCH_TREE AS SEARCH_TREE2 
                    WHERE SEARCH_TREE2.STR_ID_PARENT <=> SEARCH_TREE.STR_ID LIMIT 1 ), 1, 0) AS DESCENDANTS 
            FROM SEARCH_TREE 
            INNER JOIN DESIGNATIONS ON DES_ID = STR_DES_ID 
            INNER JOIN DES_TEXTS ON TEX_ID = DES_TEX_ID 
            WHERE STR_ID_PARENT <=> @STR_ID AND DES_LNG_ID = @LNG_ID AND EXISTS 
            (   SELECT * 
                FROM LINK_GA_STR 
                INNER JOIN LINK_LA_TYP ON LAT_TYP_ID = @TYP_ID AND LAT_GA_ID = LGS_GA_ID 
                INNER JOIN LINK_ART ON LA_ID = LAT_LA_ID WHERE LGS_STR_ID = STR_ID LIMIT 1 )
          */
        
        public async Task<ICollection<SearchTree>> GetAppliableNodes(int typeId, int? parentNode = null)
        {
            var groupToTreeLinkSet = Context.Set<GroupToTreeLink>();
            var typeToArticleLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var groupToArticleLinkSet = Context.Set<LinkArt>();
            var searchTreeNodeSet = Context.Set<SearchTree>();

            var x =
                from treeNode in searchTreeNodeSet
                where treeNode.ParentId == parentNode &&
                      (from groupTreeLink in groupToTreeLinkSet
                          join typeArticleLink in typeToArticleLinkSet on 
                              new {GroupId = groupTreeLink.GaId, TypeId = typeId} 
                              equals 
                              new {GroupId = typeArticleLink.LatGaId, TypeId = typeArticleLink.TypeId}
                          join groupArticleLink in groupToArticleLinkSet on 
                              typeArticleLink.LinkArtId 
                              equals 
                              groupArticleLink.Id
                          where groupTreeLink.SearchTreeId == treeNode.Id
                          select groupTreeLink).Take(1).Any()
                select treeNode;

            return await x.AsNoTracking().ToListAsync();

        }
    }
}