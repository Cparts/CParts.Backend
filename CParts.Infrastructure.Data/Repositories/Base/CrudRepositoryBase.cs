using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data
{
    public abstract class CrudRepositoryBase<TEntity, TKey> : ReadRepositoryBase<TEntity>, ICrudRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        private readonly IDbContext _context;
        protected IDbContext Context => _context;

        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet => _dbSet;

        protected CrudRepositoryBase(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        protected abstract Expression<Func<TEntity, bool>> KeyPredicate(TKey key);
        protected abstract IQueryable<TEntity> MapNavigationProperties(IQueryable<TEntity> entitySet);

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
            return await _context.SaveChangesAsync();
        }
    }
}