using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Services.Abstractions;
using CParts.Services.Abstractions.ViewModels;

namespace CParts.Infrastructure.Services
{
    public class AnaloguesServiceWrapper : IAnaloguesServiceWrapper
    {
        private readonly IArticleAnaloguesService _articleAnaloguesService;

        public AnaloguesServiceWrapper(IArticleAnaloguesService articleAnaloguesService)
        {
            _articleAnaloguesService = articleAnaloguesService;
        }

        public async Task<ICollection<ArticleAnalogueViewModel>> GetAnaloguesForArticleAsync(int articleId)
        {
            var analogues = await _articleAnaloguesService.GetAnaloguesForArticleAsync(articleId);
            var viewModels = analogues.Select(x => new ArticleAnalogueViewModel
            {
                ArticleId = x.ArticleId,
                IsBrand = x.Kind != 2,
                BrandOrSupplier = x.Kind == 2 ? x.Supplier.Brand : x.Brand.Name,
                BrandOrSupplierId = x.Kind == 2 ? x.SupplierId : x.BrandId,
                Kind = (Kind) x.Kind,
                DisplayNumber = x.DisplayNumber
            }).ToList();
            return viewModels;
        }
    }
}