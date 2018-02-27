using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Additional;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class FullIdentifiersRepository : ReadRepositoryBase<FullTypeIdentifier, IPartsDataDbContext>, IFullIdentifiersRepository
    {
        public FullIdentifiersRepository(IPartsDataDbContext context) : base(context)
        {
        }


        public async Task<dynamic> SearchByQueryAsync(string sookablyat)
        {
            var query = from str in Context.Set<SearchTree>()
                join lgs in Context.Set<GroupToTreeLink>() on str.Id equals lgs.SearchTreeId
                join lat in Context.Set<ArticleLinkToTypeLink>() on lgs.GaId equals lat.LatGaId
                join type in Context.Set<Type>() on lat.TypeId equals type.Id
                join ftp in (Context.Set<FullTypeIdentifier>().FromSql(@"SELECT *
                    FROM FULL_TYPE_IDENTIFIER
                    WHERE MATCH ( FTP_FULL_IDENTIFIER ) AGAINST ( @p0 ) LIMIT 1", sookablyat)) on type.Id equals ftp
                    .TypeId
                join strnm in (Context.Set<SearchTreeName>()
                    .FromSql(
                        @"SELECT MIN(STR_ID) AS STR_ID, TEX_TEXT FROM SEARCH_TREE_NAME WHERE MATCH ( TEX_TEXT ) AGAINST ( @p0 ) GROUP BY TEX_TEXT",
                        sookablyat)) on str.Id equals strnm.SearchTreeId
                select new
                {
                    STR_ID = str.Id,
                    NAME = strnm.Name,
                    FTP = ftp.FullIdentifier,
                    TYP_ID = type.Id
                };

            return await query.Distinct().AsNoTracking().ToListAsync();
        }

        /*
         * SELECT
           DISTINCT
           SEARCH_TREE.STR_ID,
           X2.TEX_TEXT,
           FTP.FTP_FULL_IDENTIFIER,
           TYP_ID 
           FROM
           SEARCH_TREE
           JOIN LINK_GA_STR ON LGS_STR_ID = SEARCH_TREE.STR_ID
           JOIN LINK_LA_TYP ON LAT_GA_ID = LGS_GA_ID
           JOIN TYPES ON TYP_ID = LAT_TYP_ID 
           JOIN (SELECT FTP_TYP_ID, FTP_FULL_IDENTIFIER FROM FULL_TYPE_IDENTIFIER WHERE MATCH ( FTP_FULL_IDENTIFIER ) AGAINST ( @SRCH_QRY ) LIMIT 1 ) AS FTP ON FTP.FTP_TYP_ID = TYP_ID
           JOIN (SELECT MIN(STR_ID) AS STR_ID, TEX_TEXT FROM SEARCH_TREE_NAME WHERE MATCH ( TEX_TEXT ) AGAINST ( @SRCH_QRY ) GROUP BY TEX_TEXT) AS X2 ON X2.STR_ID = SEARCH_TREE.STR_ID;
         */
    }
}