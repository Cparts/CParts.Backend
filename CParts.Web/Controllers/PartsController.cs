using System.Threading.Tasks;
using CParts.Business.Abstractions.Parts;
using CParts.Services.Abstractions.Parts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CParts.Web.Controllers
{
    [Route("api/v1/parts")]
    public class PartsController : Controller
    {
        private readonly ISearchTreeService _searchTreeService;
        private readonly IArticlesServiceMapper _articlesServiceMapper;
        private readonly IApplicabilityServiceMapper _applicabilityServiceMapper;
        private readonly ICarSelectionServiceMapper _carSelectionServiceMapper;
        private readonly IAnaloguesServiceMapper _analoguesServiceMapper;

        public PartsController(ISearchTreeService searchTreeService,
            IArticlesServiceMapper articlesServiceMapper, IApplicabilityServiceMapper applicabilityServiceMapper,
            ICarSelectionServiceMapper carSelectionServiceMapper,
            IAnaloguesServiceMapper analoguesServiceMapper)
        {
            _searchTreeService = searchTreeService;
            _articlesServiceMapper = articlesServiceMapper;
            _applicabilityServiceMapper = applicabilityServiceMapper;
            _carSelectionServiceMapper = carSelectionServiceMapper;
            _analoguesServiceMapper = analoguesServiceMapper;
        }

        [HttpGet]
        [Authorize]
        [Route("manufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            return Ok(await _carSelectionServiceMapper.GetAllManufacturerAsync());
        }

        [HttpGet]
        [Route("manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetModels(int manufacturerId, int page = 1, int lang = 4)
        {
            return Ok(await _carSelectionServiceMapper.GetModelsByManufacturerAsync(manufacturerId, page, lang));
        }

        [HttpGet]    
        [Route("models/{modelId}/types")]
        public async Task<IActionResult> GetTypes(int modelId, int lang = 4)
        {
            return Ok(await _carSelectionServiceMapper.GetTypesByModelAsync(modelId, lang));
        }

        [HttpGet]
        [Route("types/{typeId}/searchtree/{searchTree?}")]
        public async Task<IActionResult> GetNodes(int typeId, int? searchTree = null)
        {
            return Ok(await _searchTreeService.GetAppliableNodesAsync(typeId, searchTree));
        }

        [HttpGet]
        [Route("types/{typeId}/searchtree/{searchTree}/articles")]
        public async Task<IActionResult> GetArticles(int typeId, int searchTree, int lang = 4)
        {
            return Ok(await _articlesServiceMapper.GetByTypeAndTreeNodeAsync(typeId, searchTree, lang));
        }

        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers")]
        public async Task<IActionResult> GetApplicabilityManufacturers(int articleId, int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetManufacturersWithApplicableModels(articleId, lang));
        }

        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetApplicabilityModels(int articleId, int manufacturerId, int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetModelsWithApplicableTypes(articleId, manufacturerId, lang));
        }

        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models/{modelId}/types")]
        public async Task<IActionResult> GetApplicabilityTypes(int articleId, int manufacturerId, int modelId,
            int lang = 4)
        {
            return Ok(await _applicabilityServiceMapper.GetApplicableTypesByModel(articleId, modelId, lang));
        }

        [HttpGet]
        [Route("articles/{articleId}/analogues")]
        public async Task<IActionResult> GetAnalogues(int articleId)
        {
            return Ok(await _analoguesServiceMapper.GetAnaloguesForArticleAsync(articleId));
        }
    }
}