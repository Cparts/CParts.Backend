﻿using System.Collections.Generic;
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
            await _generalDesignationsRepository.AppendDesignationsToCollection(articles);
            return articles;
        }

        public async Task<ICollection<ArticleLookup>> GetOriginalsForArticlesAsync(IEnumerable<Article> articles)
        {
            var articleIds = articles.Select(x => x.Id).ToList();
            var originals = await _articleLookupRepository.FindOriginalsForAritclesRange(articleIds);
            return originals;
        }

        public async Task<ICollection<ArticleCriteria>> GetCriteriasAsync(int articleId)
        {
            return await _articleCriteriasRepository.GetByArticleId(articleId);
        }

        public async Task<ICollection<ArticleCriteria>> GetCriteriasForRangeAsync(ICollection<Article> articles)
        {
            var ids = articles.Select(x => x.Id);
            var criterias = await _articleCriteriasRepository.GetByArticleIds(ids);
            await _generalDesignationsRepository.AppendDesignationsToCollection(criterias);
            await _generalDesignationsRepository.AppendDesignationsToCollection(criterias.Select(x => x.Criteria).ToList());
            return criterias;
        }
    }
}