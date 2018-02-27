using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Framework;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ModelsRepository : ReadRepositoryBase<Model, IPartsDataDbContext>, IModelsRepository
    {
        public ModelsRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<PaginatedResult<Model>> GetByManufacturerAsync(int manufacturerId,
            int page = 1, int pageSize = 25, 
            Expression<Func<Model, IComparable>> sortOrder = null,
            OrderDirection sortDirection = OrderDirection.Ascending)
        {
            var query = from model in DbSet
                where model.ManufacturerId == manufacturerId
                select model;

            if (sortOrder == null)
                sortOrder = x => x.Id;
            
            return await query.PaginateAsync(pageSize, page, sortOrder, sortDirection);
        }     
        
        public async Task<ICollection<Model>> GetByManufacturerAndYearAsync(int manufacturerId, int year)
        {
            var query = from model in DbSet
                where model.ManufacturerId == manufacturerId && model.PconStart / 100 < year && year < model.PconEnd / 100
                select model;

            return await query.AsNoTracking().ToListAsync();
        }
    }
}