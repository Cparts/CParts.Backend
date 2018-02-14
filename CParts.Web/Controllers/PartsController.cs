using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CParts.Web.Controllers
{
    [Route("api/v1/parts")]
    public class PartsController : Controller
    {
        private readonly ISearchTreeService _searchTreeService;
        private readonly IArticlesServiceWrapper _articlesServiceWrapper;
        private readonly IApplicabilityServiceWrapper _applicabilityServiceWrapper;
        private readonly ICarSelectionServiceWrapper _carSelectionServiceWrapper;

        public PartsController(ISearchTreeService searchTreeService,
            IArticlesServiceWrapper articlesServiceWrapper, IApplicabilityServiceWrapper applicabilityServiceWrapper, ICarSelectionServiceWrapper carSelectionServiceWrapper)
        {
            _searchTreeService = searchTreeService;
            _articlesServiceWrapper = articlesServiceWrapper;
            _applicabilityServiceWrapper = applicabilityServiceWrapper;
            _carSelectionServiceWrapper = carSelectionServiceWrapper;
        }

        [HttpGet]
        [Route("manufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            return Ok(await _carSelectionServiceWrapper.GetAllManufacturerAsync());
        }

        [HttpGet]
        [Route("manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetModels(int manufacturerId, int lang = 4)
        {
            return Ok(await _carSelectionServiceWrapper.GetModelsByManufacturerAsync(manufacturerId, lang));
        }

        [HttpGet]
        [Route("models/{modelId}/types")]
        public async Task<IActionResult> GetTypes(int modelId, int lang = 4)
        {
            return Ok(await _carSelectionServiceWrapper.GetTypesByModelAsync(modelId, lang));
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
            return Ok(await _articlesServiceWrapper.GetByTypeAndTreeNodeAsync(typeId, searchTree, lang));
        }

        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers")]
        public async Task<IActionResult> GetApplicabilityManufacturers(int articleId, int lang = 4)
        {
            return Ok(await _applicabilityServiceWrapper.GetManufacturersWithApplicableModels(articleId,lang));
        }
        
        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models")]
        public async Task<IActionResult> GetApplicabilityModels(int articleId, int manufacturerId, int lang = 4)
        {
            return Ok(await _applicabilityServiceWrapper.GetModelsWithApplicableTypes(articleId, manufacturerId, lang));
        }
        
        [HttpGet]
        [Route("articles/{articleId}/applicable/manufacturers/{manufacturerId}/models/{modelId}/types")]
        public async Task<IActionResult> GetApplicabilityTypes(int articleId, int manufacturerId, int modelId, int lang = 4)
        {
            return Ok(await _applicabilityServiceWrapper.GetApplicableTypesByModel(articleId, modelId, lang));
        }
        

    }
}