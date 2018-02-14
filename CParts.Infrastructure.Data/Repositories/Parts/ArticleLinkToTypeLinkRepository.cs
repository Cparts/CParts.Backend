using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class ArticleLinkToTypeLinkRepository : ReadRepositoryBase<ArticleLinkToTypeLink, IPartsDataDbContext>,
        IArticleLinkToTypeLinkRepository
    {
        public ArticleLinkToTypeLinkRepository(IPartsDataDbContext context) : base(context)
        {
        }
    }
}