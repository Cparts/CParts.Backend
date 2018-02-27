using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Parts;
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

        public async Task<SearchThirdStepViewModel> GetModelsByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4)
        {
            var queryResult = await _carSelectionService.GetByManufacturerAsync(manufacturerId, page, languageId);
            var models = queryResult.PageContent.Select(x => new ModelsViewModel
            {
                Description = x.CountryDesignation.Text.Text,
                Id = x.Id,
                ProductionStartDate = GetPconDate(x.PconStart),
                ProductionEndDate = GetPconDate(x.PconEnd)
            }).ToList();
            //TODO: Fix this (return proper model instead of search VM)
            return new SearchThirdStepViewModel();
        }
        
        public async Task<SearchThirdStepViewModel> GetModelsByManufacturerAndYearAsync(int manufacturerId, int year, int languageId = 4)
        {
            var queryResult = await _carSelectionService.GetByManufacturerAndYearAsync(manufacturerId, year, languageId);
            var models = queryResult.Models.Select(x => new ModelsViewModel
            {
                Description = x.CountryDesignation.Text.Text,
                Id = x.Id,
                ProductionStartDate = GetPconDate(x.PconStart),
                ProductionEndDate = GetPconDate(x.PconEnd)
            }).OrderBy(x => x.Description).ToList();
            return new SearchThirdStepViewModel
            {
                ManufacturerId = queryResult.Manufacturer.Id,
                ManufacturerName = queryResult.Manufacturer.Brand,
                Models = models
            };
        }

        public async Task<SearchFourthStepViewModel> GetTypesByModelAsync(int modelId, int languageId = 4)
        {
            //TODO: Swap it to proper viewmodel
            var types = (await _carSelectionService.GetByModelAsync(modelId,languageId)).Select(x => new CarType
            {
                BodyType = x.Type.KvBodyDesignation.Text.Text,
                EngineCode = x.Engine.Code,
                EngineVolume = x.Engine.LitresFrom
                               ?? 0, 
                FullEngineDescription = x.Engine.KvEngineDesignation?.Text.Text,
                FuelType = x.Engine.KvFuelTypeDesignation?.Text.Text ?? "None",
                HpPower = x.Engine.HpUpto ?? 0,
                KwPower = x.Engine.KwUpto ?? 0
            }).ToList();
            
            return new SearchFourthStepViewModel{ Types = types};
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