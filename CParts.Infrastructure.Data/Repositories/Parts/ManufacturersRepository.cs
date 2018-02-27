using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ManufacturersRepository : ReadRepositoryBase<Manufacturer, IPartsDataDbContext>, IManufacturersRepository
    {
        public ManufacturersRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<Manufacturer> GetSingleByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}