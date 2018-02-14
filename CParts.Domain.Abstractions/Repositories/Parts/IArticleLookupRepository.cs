using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IArticleLookupRepository : IReadRepository<ArticleLookup>
    {
        Task<ICollection<ArticleLookup>> FindOriginalsForAritclesRange(IEnumerable<int> articleIds);
    }
}