using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions;

namespace CParts.Infrastructure.Services
{
    public class CarSelectionServiceWrapper : ICarSelectionServiceWrapper
    {
        private readonly ICarSelectionService _carSelectionService;

        public CarSelectionServiceWrapper(ICarSelectionService carSelectionService)
        {
            _carSelectionService = carSelectionService;
        }

        public async Task<ICollection<Manufacturer>> GetAllManufacturerAsync()
        {
            return await _carSelectionService.GetManufacturersAsync();
        }

        public async Task<ICollection<Model>> GetModelsByManufacturerAsync(int manufacturerId, int languageId = 4)
        {
            return await _carSelectionService.GetByManufacturerAsync(manufacturerId, languageId);
        }

        public async Task<ICollection<Type>> GetTypesByModelAsync(int modelId, int languageId = 4)
        {
            return await _carSelectionService.GetByModelAsync(modelId,languageId);
        }
    }
}