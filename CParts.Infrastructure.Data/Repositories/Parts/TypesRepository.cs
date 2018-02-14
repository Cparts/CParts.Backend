using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Links;
using CParts.Framework;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Type = CParts.Domain.Core.Model.Parts.Type;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class TypesRepository : ReadRepositoryBase<Type, IPartsDataDbContext>, ITypesRepository
    {
        public TypesRepository(IPartsDataDbContext context) : base(context)
        {
        }

        [Obsolete("Use another (step-by-step) methods instead")]
        public async Task<ICollection<Type>> GetPartApplicabilityAsync(int articleId)
        {
            var groupToArticleLinkSet = Context.Set<LinkArt>();
            var articleToTypeLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var typesSet = Context.Set<Type>();

            var query = (from linkArt in groupToArticleLinkSet
                join artToTypeLink in articleToTypeLinkSet on linkArt.Id equals artToTypeLink.LinkArtId
                join type in typesSet on artToTypeLink.TypeId equals type.Id
                where linkArt.ArticleId == articleId
                select type);

            query = query.Include(x => x.Model).ThenInclude(x => x.Manufacturer).AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<ICollection<Type>> GetByModelAsync(int modelId)
        {
            var query = from type in DbSet
                where type.ModelId == modelId
                select type;

            query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        
        //TODO: Rewrite queries
        public async Task<ICollection<Manufacturer>> GetPartApplicabilityMfsAsync(int articleId)
        {
            var groupToArticleLinkSet = Context.Set<LinkArt>();
            var articleToTypeLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var typesSet = Context.Set<Type>();

            var query = (from linkArt in groupToArticleLinkSet
                join artToTypeLink in articleToTypeLinkSet on linkArt.Id equals artToTypeLink.LinkArtId
                join type in typesSet on artToTypeLink.TypeId equals type.Id
                where linkArt.ArticleId == articleId
                select type.Model.Manufacturer);

            query = query.DistinctBy(x => x.Id).AsNoTracking();

            return await query.ToListAsync();
        }
        
        public async Task<ICollection<Model>> GetPartApplicabilityMdlsAsync(int articleId, int mfId)
        {
            var groupToArticleLinkSet = Context.Set<LinkArt>();
            var articleToTypeLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var typesSet = Context.Set<Type>();

            var query = (from linkArt in groupToArticleLinkSet
                join artToTypeLink in articleToTypeLinkSet on linkArt.Id equals artToTypeLink.LinkArtId
                join type in typesSet on artToTypeLink.TypeId equals type.Id
                where linkArt.ArticleId == articleId && type.Model.Manufacturer.Id == mfId
                select type.Model).DistinctBy(x => x.Id);

            query = query.AsNoTracking();

            return await query.ToListAsync();
        }        
        
        public async Task<ICollection<Type>> GetPartApplicabilityTypesAsync(int articleId, int modelId)
        {
            var groupToArticleLinkSet = Context.Set<LinkArt>();
            var articleToTypeLinkSet = Context.Set<ArticleLinkToTypeLink>();
            var typesSet = Context.Set<Type>();

            var query = (from linkArt in groupToArticleLinkSet
                join artToTypeLink in articleToTypeLinkSet on linkArt.Id equals artToTypeLink.LinkArtId
                join type in typesSet on artToTypeLink.TypeId equals type.Id
                where linkArt.ArticleId == articleId && type.ModelId == modelId
                select type);

            query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}