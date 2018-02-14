using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts.Contracts;

namespace CParts.Domain.Abstractions.Repositories.Parts.Base
{
    public interface IDesignationsRepository<TDesignationEntity> : IReadRepository<TDesignationEntity>
        where TDesignationEntity : class, IDesignation
    {
        Task<TDesignationEntity> GetByIdAndLanguageAsync(int id, int languageId);
        Task<ICollection<TDesignationEntity>> GetByIdAndLanguageAsync(IEnumerable<int?> ids, int languageId);

        Task<ICollection<TEntity>> AppendDesignationsToCollection<TEntity>(
            ICollection<TEntity> entityCollection,
            int languageId = 4);
    }
}