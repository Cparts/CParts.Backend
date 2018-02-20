using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Base
{
    public abstract class ReadRepositoryBase<TEntity, TContext> : IReadRepository<TEntity>
    where TEntity : class
    where TContext : IDbContext
    {
        private readonly IDbContext _context;
        protected IDbContext Context => _context;

        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet => _dbSet;

        protected ReadRepositoryBase(TContext context)
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
    }
}