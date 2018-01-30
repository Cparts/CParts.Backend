using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Core;

namespace CParts.Infrastructure.Data
{
    public abstract class TrackedCrudRepositoryBase<TEntity, TKey> : CrudRepositoryBase<TEntity, TKey>
        where TKey : IEquatable<TKey> 
        where TEntity : class, ITrackedEntity
    {
        protected TrackedCrudRepositoryBase(IPartsDataDbContext context) : base(context)
        {
        }

        public override Task CreateAsync(TEntity entity)
        {
            var timeNow = DateTime.Now;
            entity.CreateTimeStamp = timeNow;
            entity.UpdateTimeStamp = timeNow;
            return base.CreateAsync(entity);
        }

        public override Task UpdateAsync(TEntity entity)
        {
            entity.UpdateTimeStamp = DateTime.Now;
            return base.UpdateAsync(entity);
        }
    }
}