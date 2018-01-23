using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CParts.Domain.Abstractions
{
    public interface IRepository<TEntity, in TKey>
    where TEntity : class
    where TKey : IEquatable<TKey>
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey entityKey);
        Task<ICollection<TEntity>> AllAsync(bool mapNavigationProperties = false);
        Task<TEntity> FindByKeyAsync(TKey entityKey, bool mapNavigationProperties = false);
        //TODO: Change. Can lead to unpredictable results like returning IQueryable from method which is undesirable
        Task<TResult> SelectAsync<TResult>(Func<IQueryable<TEntity>, Task<TResult>> query);
    }
}