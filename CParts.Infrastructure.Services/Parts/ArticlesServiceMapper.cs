using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.Parts;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Infrastructure.Services.Parts
{
    public class ArticlesServiceMapper : IArticlesServiceMapper
    {
        private readonly IArticlesService _articlesService;

        public ArticlesServiceMapper(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        public async Task<ICollection<ArticleViewModel>> GetByTypeAndTreeNodeAsync(int typeId, int treeNode,
            int lang = 4)
        {
            var thirdPartyArticles = await _articlesService.GetNonOriginalsByTypeAndNodeAsync(typeId, treeNode, lang);
            var originalArticles = await _articlesService.GetOriginalsForArticlesAsync(thirdPartyArticles);
            var criterias = await _articlesService.GetCriteriasForRangeAsync(thirdPartyArticles);

            var result = ConvertModelToViewModel(thirdPartyArticles, originalArticles, criterias);
            
            return result;
        }

        //TODO: Move this converters
        private ICollection<ArticleViewModel> ConvertModelToViewModel(ICollection<Article> articles,
            ICollection<ArticleLookup> originals, ICollection<ArticleCriteria> criterias)
        {
            var result = new List<ArticleViewModel>(articles.Count + originals.Count);

            foreach (var thirdPartyArticle in articles)
            {
                result.Add(ConvertBusinessModelToViewModel(thirdPartyArticle, originals, criterias));
            }

            return result;
        }
        
        private ArticleViewModel ConvertBusinessModelToViewModel(Article article, ICollection<ArticleLookup> originals,
            ICollection<ArticleCriteria> criterias)
        {
            return new ArticleViewModel
            {
                Brand = article.Supplier?.Brand,
                CompleteDescription = article.CompleteDesignation?.Text.Text,
                Description = article.Designation?.Text.Text,
                DisplayNumber = article.Number,
                Id = article.Id,
                Originals = originals.Where(x => x.ArticleId == article.Id).Select(x => ConvertToModel(x)).ToList(),
                Specs = criterias.Where(x => x.ArticleId == article.Id).Select(ConvertToModel).ToList()
            };
        }

        private OriginalArticleViewModel ConvertToModel(ArticleLookup articleLookup)
        {
            return new OriginalArticleViewModel
            {
                Brand = articleLookup.Brand?.Name,
                DisplayNumber = articleLookup.DisplayNumber,
                Id = articleLookup.ArticleId
            };
        }

        private SpecificationViewModel ConvertToModel(ArticleCriteria criteria)
        {
            return new SpecificationViewModel
            {
                Description = criteria.Criteria.Designation?.Text.Text,
                KvDescription = criteria.KvDesignation?.Text.Text,
                ShortDescription = criteria.Criteria.ShortDesignation?.Text.Text,
                UnitDescription = criteria.Criteria.UnitDesignation?.Text.Text,
                Value = criteria.Value
            };
        }
        
    }
}