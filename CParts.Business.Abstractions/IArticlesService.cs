using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Business.Abstractions
{
    public interface IArticlesService
    {
        Task<ICollection<Article>> GetNonOriginalsByTypeAndNodeAsync(int typeId, int nodeId, int languageId = 4);
        Task<ICollection<ArticleLookup>> GetOriginalsForArticlesAsync(IEnumerable<Article> articles);
        Task<ICollection<ArticleCriteria>> GetCriteriasAsync(int articleId);
        Task<ICollection<ArticleCriteria>> GetCriteriasForRangeAsync(ICollection<Article> articles);
    }
}