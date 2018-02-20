using System.Collections.Generic;
using System.Threading.Tasks;

namespace CParts.Domain.Abstractions.Repositories.Base
{
    public interface IReadRepository<TEntity>
    where TEntity : class
    {
        Task<ICollection<TEntity>> AllAsync(bool mapNavigationProperties = false);
    }
}