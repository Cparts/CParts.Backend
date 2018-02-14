using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CParts.Domain.Abstractions.Repositories.Base
{
    public interface IReadRepository<TEntity>
    where TEntity : class
    {
        Task<ICollection<TEntity>> AllAsync(bool mapNavigationProperties = false);
        //TODO: Fix. Can lead to unpredictable results like returning IQueryable from method which is undesirable
        Task<TResult> SelectAsync<TResult>(Func<IQueryable<TEntity>, Task<TResult>> query);
    }
}