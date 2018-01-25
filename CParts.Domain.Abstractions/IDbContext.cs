using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CParts.Domain.Abstractions
{
    public interface ICPartsContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken());
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}