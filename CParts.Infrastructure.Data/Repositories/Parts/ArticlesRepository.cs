using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Base;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ArticlesRepository : ReadRepositoryBase<Article, IPartsDataDbContext>, IArticlesRepository
    {
        public ArticlesRepository(IPartsDataDbContext context) : base(context)
        {
        }

    }
}