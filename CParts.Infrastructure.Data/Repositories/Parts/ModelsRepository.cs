using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ModelsRepository : ReadRepositoryBase<Model, IPartsDataDbContext>, IModelsRepository
    {
        public ModelsRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Model>> GetByManufacturerAsync(int manufacturerId)
        {
            var query = from model in DbSet
                where model.ManufacturerId == manufacturerId
                select model;

            query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}