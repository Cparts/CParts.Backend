using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories;

namespace CParts.Infrastructure.Data.Repositories.Base
{
    public class PartsReadRepository<TEntity> : ReadRepositoryBase<TEntity>
    where TEntity : class
    {
        public PartsReadRepository(IPartsDataDbContext context) : base(context)
        {
        }
    }
}