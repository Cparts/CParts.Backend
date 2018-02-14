using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.ViewModels;

namespace CParts.Services.Abstractions
{
    public interface IArticlesServiceWrapper
    {
        Task<ICollection<ArticleViewModel>> GetByTypeAndTreeNodeAsync(int typeId, int treeNode, int lang = 4);
    }
}