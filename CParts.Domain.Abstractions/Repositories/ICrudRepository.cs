using System;
using System.Threading.Tasks;

namespace CParts.Domain.Abstractions.Repositories
{
    public interface ICrudRepository<TEntity, in TKey> : IReadRepository<TEntity>
    where TEntity : class
    where TKey : IEquatable<TKey>
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey entityKey);
        Task<TEntity> FindByKeyAsync(TKey entityKey, bool mapNavigationProperties = false);
    }
}