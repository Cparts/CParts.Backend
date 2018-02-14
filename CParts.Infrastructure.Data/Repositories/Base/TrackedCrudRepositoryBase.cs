using System;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Core.Model.Internal.Contracts;

namespace CParts.Infrastructure.Data.Repositories.Base
{
    public abstract class TrackedCrudRepositoryBase<TEntity, TKey, TContext> : CrudRepositoryBase<TEntity, TKey, TContext>
        where TKey : IEquatable<TKey> 
        where TEntity : class, ITrackedEntity
        where TContext : IDbContext
    {
        protected TrackedCrudRepositoryBase(TContext context) : base(context)
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