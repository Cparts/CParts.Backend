using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Services.Abstractions.Parts
{
    public interface IArticlesServiceMapper
    {
        Task<ICollection<ArticleViewModel>> GetByTypeAndTreeNodeAsync(int typeId, int treeNode, int lang = 4);
    }
}