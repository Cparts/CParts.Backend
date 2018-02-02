using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model;

namespace CParts.Services.Abstractions
{
    public interface ITypesService
    {
        Task<ICollection<Type>> GetByModelId(int modelId, int? languageId = null);
        Task<ICollection<LinkLaTyp>> BuildSearchTree(int typeId);
    }
}