using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions;
using CParts.Domain.Abstractions.Repositories;

namespace CParts.Infrastructure.Data
{
    public class ReadRepositoryBase<TEntity> : IReadRepository<TEntity>
    where TEntity : class
    {
        public Task<ICollection<TEntity>> AllAsync(bool mapNavigationProperties = false)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> SelectAsync<TResult>(Func<IQueryable<TEntity>, Task<TResult>> query)
        {
            throw new NotImplementedException();
        }
    }
}