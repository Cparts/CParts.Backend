using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Base;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ManufacturersRepository : ReadRepositoryBase<Manufacturer, IPartsDataDbContext>, IManufacturersRepository
    {
        public ManufacturersRepository(IPartsDataDbContext context) : base(context)
        {
        }

    }
}