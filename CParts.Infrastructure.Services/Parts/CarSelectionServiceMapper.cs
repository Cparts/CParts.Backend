using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.Parts;
using CParts.Services.Abstractions.Parts.ViewModels;
using Type = CParts.Domain.Core.Model.Parts.Type;

namespace CParts.Infrastructure.Services.Parts
{
    public class CarSelectionServiceMapper : ICarSelectionServiceMapper
    {
        private readonly ICarSelectionService _carSelectionService;

        public CarSelectionServiceMapper(ICarSelectionService carSelectionService)
        {
            _carSelectionService = carSelectionService;
        }

        public async Task<ICollection<Manufacturer>> GetAllManufacturerAsync()
        {
            return await _carSelectionService.GetManufacturersAsync();
        }

        public async Task<ICollection<ModelViewModel>> GetModelsByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4)
        {
            var queryResult = await _carSelectionService.GetByManufacturerAsync(manufacturerId, page, languageId);
            return queryResult.Select(x => new ModelViewModel
            {
                Description = x.CountryDesignation.Text.Text,
                Id = x.Id,
                ProductionStartDate = GetPconDate(x.PconStart),
                ProductionEndDate = GetPconDate(x.PconEnd)
            }).ToList();
        }

        public async Task<ICollection<Type>> GetTypesByModelAsync(int modelId, int languageId = 4)
        {
            return await _carSelectionService.GetByModelAsync(modelId,languageId);
        }

        private DateTime GetPconDate(int? pcon)
        {
            if (!pcon.HasValue)
            {
                return DateTime.Now;
            }
            return new DateTime(GetPconYear(pcon), GetPconMonth(pcon), 1);
        }
        
        private int GetPconYear(int? pcon)
        {
            if (!pcon.HasValue)
                return 0;
            return pcon.Value / 100;
        }

        private int GetPconMonth(int? pcon)
        {
            if (!pcon.HasValue)
                return 0;
            return pcon.Value - pcon.Value / 100 * 100;
        }
    }
}