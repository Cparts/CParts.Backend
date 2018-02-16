using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Services.Abstractions.ViewModels;

namespace CParts.Services.Abstractions
{
    public interface IAnaloguesServiceWrapper
    {
        Task<ICollection<ArticleAnalogueViewModel>> GetAnaloguesForArticleAsync(int articleId);
    }
}