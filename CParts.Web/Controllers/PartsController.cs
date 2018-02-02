using System.Threading.Tasks;
using CParts.Services.Abstractions;
using CParts.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CParts.Web.Controllers
{
    [Route("api/v1/parts")]
    public class PartsController : Controller
    {
        private readonly IArtLookupService _artLookupService;
        private readonly IBrandsService _brandsService;
        private readonly IManufacturersService _manufacturersService;
        private readonly IModelsService _modelsService;
        private readonly ITypesService _typesService;

        public PartsController(IBrandsService brandsService, IArtLookupService artLookupService, IManufacturersService manufacturersService, IModelsService modelsService, ITypesService typesService)
        {
            _brandsService = brandsService;
            _artLookupService = artLookupService;
            _manufacturersService = manufacturersService;
            _modelsService = modelsService;
            _typesService = typesService;
        }

        [HttpGet]
        [Route("artLookup/{sdata}")]
        public async Task<IActionResult> GetSomeData(string sdata)
        {
            return Ok(await _artLookupService.GetSomeData(sdata));
        }

        [HttpGet]
        [Route("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            return Ok(await _brandsService.AllAsync());
        }

        [HttpGet]
        [Route("manufacturers")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            return Ok(await _manufacturersService.GetAll());
        }

        [HttpGet]
        [Route("manufacturers/{id}/models")]
        public async Task<IActionResult> GetManufacturerModels(int id)
        {
            return Ok(await _modelsService.GetByManufacturer(id));
        }

        [HttpGet]
        [Route("models/{modId}/types")]
        public async Task<IActionResult> GetModelModifications(int modId, int? lang = 1)
        {
            return Ok(await _typesService.GetByModelId(modId,lang));
        }

        [HttpGet]
        [Route("models/llts/{typeId}")]
        public async Task<IActionResult> GetLLTs(int typeId)
        {
            return Ok(await _typesService.BuildSearchTree(typeId));
        }

        [HttpGet]
        [Route("manufacturers/{manufacturerId}/year/{year}")]
        public async Task<IActionResult> GetMfModelsByYear(int manufacturerId, int year)
        {
            return Ok(await _modelsService.GetByManufacturerAndYear(manufacturerId, year));
        }

    }
}