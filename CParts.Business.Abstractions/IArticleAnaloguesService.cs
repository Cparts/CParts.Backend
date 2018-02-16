using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.QueryModels;

namespace CParts.Business.Abstractions
{
    public interface IArticleAnaloguesService
    {
        Task<ICollection<AnalogueQueryArtLookup>> GetAnaloguesForArticleAsync(int articleId);
    }
}