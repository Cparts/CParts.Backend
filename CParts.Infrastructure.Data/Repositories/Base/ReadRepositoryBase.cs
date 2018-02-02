using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Base
{
    public abstract class ReadRepositoryBase<TEntity> : IReadRepository<TEntity>
    where TEntity : class
    {
        private readonly IDbContext _context;
        protected IDbContext Context => _context;

        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet => _dbSet;

        protected ReadRepositoryBase(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> MapNavigationProperties(IQueryable<TEntity> entitySet) => entitySet;
        
        public virtual async Task<ICollection<TEntity>> AllAsync(bool mapNavigationProperties = false)
        {
            var fullSet = DbSet.AsNoTracking();

            if (mapNavigationProperties)
            {
                fullSet = MapNavigationProperties(fullSet);
            }

            return await fullSet.ToListAsync();
        }

        public virtual async Task<TResult> SelectAsync<TResult>(Func<IQueryable<TEntity>, Task<TResult>> query)
        {
            return await query(DbSet.AsNoTracking());
        }
    }
}