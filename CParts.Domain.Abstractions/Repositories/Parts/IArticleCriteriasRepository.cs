using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IArticleCriteriasRepository : IReadRepository<ArticleCriteria>
    {
        Task<ICollection<ArticleCriteria>> GetByArticleId(int id);
        Task<ICollection<ArticleCriteria>> GetByArticleIds(IEnumerable<int> ids);
    }
}