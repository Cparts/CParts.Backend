using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface ITypesRepository : IReadRepository<Type>
    {
        Task<ICollection<Type>> GetPartApplicabilityAsync(int articleId);
        //TODO: Rewrite queries
        Task<ICollection<Manufacturer>> GetPartApplicabilityMfsAsync(int articleId);
        Task<ICollection<Model>> GetPartApplicabilityMdlsAsync(int articleId, int mfId);
        Task<ICollection<Type>> GetPartApplicabilityTypesAsync(int articleId, int modelId);
        Task<ICollection<Type>> GetByModelAsync(int modelId);
    }
}