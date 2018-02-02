using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core.Model;
using CParts.Services.Abstractions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Type = CParts.Domain.Core.Model.Type;

namespace CParts.Infrastructure.Business
{
    public class TypesService : ITypesService
    {
        private readonly IReadRepository<Type> _typesRepository;
        private readonly IReadRepository<CountryDesignation> _countryDesignationsRepository;
        private readonly IReadRepository<LinkLaTyp> _linkLaTypRepository;
        private readonly IReadRepository<SearchTree> _searchTreeRepository;
        private readonly IReadRepository<LinkGaStr> _linkGaStrRepository;
        private readonly ILogger _logger;

        public TypesService(IReadRepository<Type> typesRepository,
            IReadRepository<CountryDesignation> countryDesignationsRepository,
            IReadRepository<LinkLaTyp> linkLaTypRepository, IReadRepository<SearchTree> searchTreeRepository,
            IReadRepository<LinkGaStr> linkGaStrRepository,
            ILoggerFactory loggerFactory)
        {
            _typesRepository = typesRepository;
            _countryDesignationsRepository = countryDesignationsRepository;
            _linkLaTypRepository = linkLaTypRepository;
            _searchTreeRepository = searchTreeRepository;
            _linkGaStrRepository = linkGaStrRepository;
            _logger = loggerFactory.CreateLogger("Query execution time watcher");
        }

        public async Task<ICollection<Type>> GetByModelId(int modelId, int? languageId = null)
        {
            var result = await _typesRepository.SelectAsync(x => x.Where(y => y.ModelId == modelId).ToListAsync());
            var designationIds = result.Select(x => x.MmtCountryDesignationId);
            Expression<Func<CountryDesignation, bool>> idsSelector = x => designationIds.Contains(x.Id);
            Expression<Func<CountryDesignation, bool>> resultingSelector = idsSelector;
            if (languageId != null)
            {
                resultingSelector = x => idsSelector.Invoke(x) && x.LanguageId == languageId;
            }

            var designations =
                await _countryDesignationsRepository.SelectAsync(x =>
                    x.Where(resultingSelector.Expand()).Include(y => y.DesignationText).ToListAsync());
            foreach (var type in result)
            {
                type.MmtCountryDesignations = designations.Where(x => x.Id == type.MmtCountryDesignationId).ToList();
            }

            return result;
        }
        
        //TODO: Temporary workaround for second level of tree
        public async Task<ICollection<LinkLaTyp>> BuildSearchTree(int typeId)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            
            var linkLaTypes = await _linkLaTypRepository.SelectAsync(x =>
                x.Where(y => y.TypeId == typeId).Take(1).ToListAsync());
            var latGaIds = linkLaTypes.Select(x => x.LatGaId);
            var linkGaStrs = await _linkGaStrRepository.SelectAsync(x => x.Where(y => latGaIds.Contains(y.GaId))
                .Include(y => y.SearchTree)
                .ToListAsync());
            IEnumerable<int> childSearchTreeIdList = new List<int>();
            foreach (var linkLaType in linkLaTypes)
            {
                linkLaType.LGS = linkGaStrs.Where(x => x.GaId == linkLaType.LatGaId).ToList();
                childSearchTreeIdList = childSearchTreeIdList.Concat(linkLaType.LGS.Select(x => x.SearchTreeId));

                foreach (var lgs in linkLaType.LGS)
                {
                    await SetChildSearchTreesInternal(lgs.SearchTree);
                }
            }
            
            
            stopwatch.Stop();
            _logger.LogWarning($"BuildSearchTree time elapsed: {stopwatch.ElapsedMilliseconds}");
            return linkLaTypes;
        }

        private async Task SetChildSearchTreesInternal(SearchTree basicTree)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (basicTree.Level == 5) return;
            basicTree.Childs = await _searchTreeRepository.SelectAsync(x =>
                x.Where(y => y.ParentId == basicTree.Id && y.Level == basicTree.Level + 1).ToListAsync());
            stopwatch.Stop();
            _logger.LogWarning($"BuildSearchTree time elapsed: {stopwatch.ElapsedMilliseconds}");
            foreach (var childTree in basicTree.Childs)
            {
                await SetChildSearchTreesInternal(childTree);
            }
        }
    }
}