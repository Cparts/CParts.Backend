using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core.Model;
using CParts.Framework;
using CParts.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CParts.Infrastructure.Business
{
    public class ArtLookupService : IArtLookupService
    {
        private readonly ILogger _logger;
        private readonly IReadRepository<ArticleLookup> _artLookupTestRepo;
        private readonly IReadRepository<Designation> _designationsRepo;

        public ArtLookupService(IReadRepository<ArticleLookup> artLookupTestRepo, ILoggerFactory logger,
            IReadRepository<Designation> designationsRepo)
        {
            _artLookupTestRepo = artLookupTestRepo;
            _designationsRepo = designationsRepo;
            _logger = logger.CreateLogger("Article Lookup query watcher");
        }

        public async Task<ICollection<ArticleLookup>> GetSomeData(string data)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = (await _artLookupTestRepo.SelectAsync(x =>
                x.Where(y => y.CatalogueCode == data) //.DistinctBy(e => e.BrandId)
                    .Include(y => y.Article)
                    .Include(y => y.Article.Supplier)
                    .Include(y => y.Brand)
                    .ToListAsync()));
            var designationIds = result.Select(x => x.Article.DesignationId);
            var designations =
                await _designationsRepo.SelectAsync(x => x.Where(y => designationIds.Contains(y.Id)).Include(y => y.Text).ToListAsync());
            foreach (var lookup in result)
            {
                var relatedArticle = lookup.Article;
                relatedArticle.Designations = designations.Where(x => x.Id == relatedArticle.DesignationId).ToList();
            }
            watch.Stop();
            _logger.LogWarning($"Time elapsed for query: {watch.ElapsedMilliseconds.ToString()}");
            return result;
        }
    }
}