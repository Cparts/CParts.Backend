using System.Threading.Tasks;
using CParts.Business.Abstractions.Parts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Services.Abstractions.Parts;
using Microsoft.AspNetCore.Mvc;

namespace CParts.Web.Controllers
{
    [Route("api/v1/generalSearch")]
    public class GeneralSearchController : Controller
    {
        private readonly ICarSelectionServiceMapper _carSelectionServiceMapper;

        public GeneralSearchController(ISearchTreeService searchTreeService,
            IArticlesServiceMapper articlesServiceMapper, IApplicabilityServiceMapper applicabilityServiceMapper,
            ICarSelectionServiceMapper carSelectionServiceMapper,
            IAnaloguesServiceMapper analoguesServiceMapper, IFullIdentifiersRepository fullIdentifiersRepository)
        {
            _carSelectionServiceMapper = carSelectionServiceMapper;
        }

        /// <summary>
        /// First step of general search.
        /// Gets all manufacturers (non paginated)
        /// </summary>
        /// <returns>List of all manufacturers</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("manufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            return Ok(await _carSelectionServiceMapper.GetAllManufacturerAsync());
        }

        /// <summary>
        /// Second-Third step of general search. (choosing the year is frontend-sided)
        /// Gets models which input {year} is between production start and production end years  
        /// </summary>
        /// <param name="manufacturerId">Manufacturer ID</param>
        /// <param name="year">Input car production year</param>
        /// <param name="lang">Language ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("manufacturers/{manufacturerId}/models/{year}")]
        public async Task<IActionResult> GetModels(int manufacturerId, int year, int lang = 4)
        {
            return Ok(await _carSelectionServiceMapper.GetModelsByManufacturerAndYearAsync(manufacturerId, year, lang));
        }
        
        /// <summary>
        /// Last step of general search.
        /// Gets all types of separate model set by {modelId}
        /// </summary>
        /// <param name="modelId">Model ID</param>
        /// <param name="lang">Language ID</param>
        /// <returns></returns>
        [HttpGet]    
        [Route("models/{modelId}/types")]
        public async Task<IActionResult> GetTypes(int modelId, int lang = 4)
        {
            return Ok(await _carSelectionServiceMapper.GetTypesByModelAsync(modelId, lang));
        }
    }
}