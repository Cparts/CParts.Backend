using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;
using CParts.Framework;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IModelsRepository : IReadRepository<Model>
    {
        Task<ICollection<Model>> GetByManufacturerAsync(int manufacturerId,
            int page = 1, int pageSize = 25, 
            Expression<Func<Model, IComparable>> sortOrder = null,
            OrderDirection sortDirection = OrderDirection.Ascending);
    }
}