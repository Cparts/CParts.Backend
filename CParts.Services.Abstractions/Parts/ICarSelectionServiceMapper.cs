using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Parts;
using CParts.Services.Abstractions.Parts.ViewModels;

namespace CParts.Services.Abstractions.Parts
{
    public interface ICarSelectionServiceMapper
    {
        Task<ICollection<Manufacturer>> GetAllManufacturerAsync();
        Task<SearchThirdStepViewModel> GetModelsByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4);
        Task<SearchFourthStepViewModel> GetTypesByModelAsync(int modelId, int languageId = 4);

        Task<SearchThirdStepViewModel> GetModelsByManufacturerAndYearAsync(int manufacturerId, int year,
            int languageId = 4);

    }
}