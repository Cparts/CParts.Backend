using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Abstractions.Repositories.Parts.Base;
using CParts.Domain.Core.Model.Parts;
using CParts.Business.Abstractions;

namespace CParts.Infrastructure.Business
{
    public class ArticlesService : IArticlesService
    {
        private readonly IGroupToArticleLinkRepository _groupToArticleLinkRepository;
        private readonly IArticleLookupRepository _articleLookupRepository;
        private readonly IGeneralDesignationsRepository _generalDesignationsRepository;
        private readonly IArticleCriteriasRepository _articleCriteriasRepository;

        public ArticlesService(IGroupToArticleLinkRepository groupToArticleLinkRepository,
            IGeneralDesignationsRepository generalDesignationsRepository,
            IArticleLookupRepository articleLookupRepository, IArticleCriteriasRepository articleCriteriasRepository)
        {
            _groupToArticleLinkRepository = groupToArticleLinkRepository;
            _generalDesignationsRepository = generalDesignationsRepository;
            _articleLookupRepository = articleLookupRepository;
            _articleCriteriasRepository = articleCriteriasRepository;
        }

        public async Task<ICollection<Article>> GetNonOriginalsByTypeAndNodeAsync(int typeId, int nodeId,
            int languageId = 4)
        {
            var links = await _groupToArticleLinkRepository.GetByTypeAndSearchNode(typeId, nodeId);
            var articles = links.Select(x => x.Article).ToList();
            await SetDesignationsForRangeAsync(articles);

            return articles;
        }

        public async Task<ICollection<ArticleLookup>> GetOriginalsForArticlesAsync(IEnumerable<Article> articles)
        {
            var articleIds = articles.Select(x => x.Id).ToList();
            var originals = await _articleLookupRepository.FindOriginalsForAritclesRange(articleIds);
            return originals;
        }

        private async Task<ICollection<Article>> SetDesignationsForRangeAsync(ICollection<Article> articles)
        {
//            var designationIds = articles.Select(x => x.DesignationId);
//            designationIds = designationIds.Concat(articles.Select(x => x.CompleteDesignationId));
//
//            var designations = await _generalDesignationsRepository.GetByIdAndLanguageAsync(designationIds, 4);
//            foreach (var article in articles)
//            {
//                article.Designation = designations.SingleOrDefault(x => x.Id == article.DesignationId);
//                article.CompleteDesignation = designations.SingleOrDefault(x => x.Id == article.CompleteDesignationId);
//            }

            await _generalDesignationsRepository.AppendDesignationsToCollection(articles);

            return articles;
        }

        public async Task<ICollection<ArticleCriteria>> GetCriteriasAsync(int articleId)
        {
            return await _articleCriteriasRepository.GetByArticleId(articleId);
        }

        public async Task<ICollection<ArticleCriteria>> GetCriteriasForRangeAsync(ICollection<Article> articles)
        {
            var ids = articles.Select(x => x.Id);
            var criterias = await _articleCriteriasRepository.GetByArticleIds(ids);
            await SetDesignationsForCriteriasRangeAsync(criterias);
            return criterias;
        }

        public async Task<ICollection<ArticleCriteria>> SetDesignationsForCriteriasRangeAsync(
            ICollection<ArticleCriteria> criterias, int langId = 4)
        {
            await _generalDesignationsRepository.AppendDesignationsToCollection(criterias);
            await _generalDesignationsRepository.AppendDesignationsToCollection(criterias.Select(x => x.Criteria).ToList());
/*            var designationIds = criterias.Select(x =>
                x.Criteria.ShortDesignationId);
            designationIds = designationIds.Concat(criterias.Select(x => x.Criteria.DesignationId).Cast<int?>());
            designationIds = designationIds.Concat(criterias.Select(x => x.Criteria.UnitDesignationId));
            designationIds = designationIds.Concat(criterias.Select(x => x.KvDesignationId));

            var designations = await _generalDesignationsRepository.GetByIdAndLanguageAsync(designationIds, langId);

            foreach (var articleCriteria in criterias)
            {
                var innerCriteria = articleCriteria.Criteria;
                innerCriteria.Designation =
                    designations.SingleOrDefault(x => x.Id == innerCriteria.DesignationId);
                innerCriteria.ShortDesignation =
                    designations.SingleOrDefault(x => x.Id == innerCriteria.ShortDesignationId);
                innerCriteria.UnitDesignation =
                    designations.SingleOrDefault(x => x.Id == innerCriteria.UnitDesignationId);
                articleCriteria.KvDesignation =
                    designations.SingleOrDefault(x => x.Id == articleCriteria.KvDesignationId);
            }*/

            return criterias;
        }
    }
}