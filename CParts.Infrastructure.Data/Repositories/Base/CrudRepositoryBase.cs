using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Base
{
    public abstract class CrudRepositoryBase<TEntity, TKey, TContext> : ReadRepositoryBase<TEntity, TContext>, ICrudRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
        where TContext : IDbContext
    {
        protected abstract Expression<Func<TEntity, bool>> KeyPredicate(TKey key);

        protected CrudRepositoryBase(TContext context) : base(context)
        {
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(TKey entityKey)
        {
            var entity = await FindByKeyAsync(entityKey);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity);
            return true;
        }

        public virtual async Task<TEntity> FindByKeyAsync(TKey entityKey, bool mapNavigationProperties = false)
        {
            var query = DbSet.AsNoTracking()
                .Where(KeyPredicate(entityKey));

            if (mapNavigationProperties)
            {
                query = MapNavigationProperties(query);
            }

            return await query.SingleOrDefaultAsync();
        }


        public virtual async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}