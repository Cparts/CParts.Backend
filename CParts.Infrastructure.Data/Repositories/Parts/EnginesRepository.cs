using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.QueryModels;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class EnginesRepository : ReadRepositoryBase<Engine, IPartsDataDbContext>, IEnginesRepository
    {
        public EnginesRepository(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<Engine> GetByTypeIdAsync(int typeId)
        {
            var query = from engLink in Context.Set<TypeToEngineLink>()
                join eng in Context.Set<Engine>() on engLink.EngineId equals eng.Id
                where engLink.TypeId == typeId
                select eng;

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<TypeEngineQueryModel>> GetByTypeIdAsync(IEnumerable<int> typeIds)
        {
            var query = from engLink in Context.Set<TypeToEngineLink>()
                join eng in Context.Set<Engine>() on engLink.EngineId equals eng.Id
                where typeIds.Contains(engLink.TypeId)
                select new TypeEngineQueryModel {Engine = eng, TypeId = engLink.TypeId};

            return await query.AsNoTracking().ToListAsync();
        }
    }
}