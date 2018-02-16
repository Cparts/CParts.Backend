using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Abstractions.QueryModels;
using CParts.Domain.Abstractions.Repositories.Parts;

namespace CParts.Infrastructure.Business
{
    public class ArticleAnaloguesService : IArticleAnaloguesService
    {
        private readonly IArticleLookupRepository _articleLookupRepository;

        public ArticleAnaloguesService(IArticleLookupRepository articleLookupRepository)
        {
            _articleLookupRepository = articleLookupRepository;
        }

        public async Task<ICollection<AnalogueQueryArtLookup>> GetAnaloguesForArticleAsync(int articleId)
        {
            var analogues = await _articleLookupRepository.FindAnaloguesForArticleAsync(articleId);
            return analogues;
        }
    }
}