using System.Threading.Tasks;
using CParts.Business.Abstractions.Parts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Services.Abstractions.Parts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CParts.Web.Controllers
{
    [Route("api/v1/parts")]
    public partial class PartsController : Controller
    {
        private readonly ISearchTreeService _searchTreeService;
        private readonly IArticlesServiceMapper _articlesServiceMapper;
        private readonly IApplicabilityServiceMapper _applicabilityServiceMapper;
        private readonly ICarSelectionServiceMapper _carSelectionServiceMapper;
        private readonly IAnaloguesServiceMapper _analoguesServiceMapper;
        private readonly IFullIdentifiersRepository _fullIdentifiersRepository;

        public PartsController(ISearchTreeService searchTreeService,
            IArticlesServiceMapper articlesServiceMapper, IApplicabilityServiceMapper applicabilityServiceMapper,
            ICarSelectionServiceMapper carSelectionServiceMapper,
            IAnaloguesServiceMapper analoguesServiceMapper, IFullIdentifiersRepository fullIdentifiersRepository)
        {
            _searchTreeService = searchTreeService;
            _articlesServiceMapper = articlesServiceMapper;
            _applicabilityServiceMapper = applicabilityServiceMapper;
            _carSelectionServiceMapper = carSelectionServiceMapper;
            _analoguesServiceMapper = analoguesServiceMapper;
            _fullIdentifiersRepository = fullIdentifiersRepository;
        }
        
        /// <summary>
        /// Gets all models of manufacturer
        /// </summary>
        /// <param name="manufacturerId">Manufacturer ID</param>
        /// <param name="page">Page number</param>
        /// <param name="lang">Language ID</param>
        /// <returns>Returns models of specified manufacturer on page specified by parameter</returns>
        [HttpGet]
        [Route("manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetAllModelsPaginated(int manufacturerId, int page = 1, int lang = 4)
        {
            return Ok(await _carSelectionServiceMapper.GetModelsByManufacturerAsync(manufacturerId, page, lang));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="searchTree"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("types/{typeId}/searchtree/{searchTree?}")]
        public async Task<IActionResult> GetNodes(int typeId, int? searchTree = null)
        {
            return Ok(await _searchTreeService.GetAppliableNodesAsync(typeId, searchTree));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="searchTree"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("types/{typeId}/searchtree/{searchTree}/articles")]
        public async Task<IActionResult> GetArticles(int typeId, int searchTree, int lang = 4)
        {
            return Ok(await _articlesServiceMapper.GetByTypeAndTreeNodeAsync(typeId, searchTree, lang));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers")]
        public async Task<IActionResult> GetApplicabilityManufacturers(int articleId, int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetManufacturersWithApplicableModels(articleId, lang));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="manufacturerId"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetApplicabilityModels(int articleId, int manufacturerId, int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetModelsWithApplicableTypes(articleId, manufacturerId, lang));
        }

        /// <summary>
        /// Some do
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="manufacturerId"></param>
        /// <param name="modelId"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models/{modelId}/types")]
        public async Task<IActionResult> GetApplicabilityTypes(int articleId, int manufacturerId, int modelId,
            int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetApplicableTypesByModel(articleId, modelId, lang));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("articles/{articleId}/analogues")]
        public async Task<IActionResult> GetAnalogues(int articleId)
        {
            return Ok(await _analoguesServiceMapper.GetAnaloguesForArticleAsync(articleId));
        }

        [HttpGet]
        [Route("kek/{loukek}")]
        public async Task<IActionResult> Loukek(string loukek)
        {
            return Ok(await _fullIdentifiersRepository.SearchByQueryAsync(loukek));
        }
    }
}