using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Services.Abstractions.Parts
{
    public interface IAnaloguesServiceMapper
    {
        Task<ICollection<ArticleAnalogueViewModel>> GetAnaloguesForArticleAsync(int articleId);
    }
}