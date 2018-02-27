using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Models;
using CParts.Domain.Core.Model.Parts;
using CParts.Framework;
using CParts.Infrastructure.Business.Parts;

namespace CParts.Business.Abstractions.Parts
{
    public interface ICarSelectionService
    {
        Task<ICollection<Manufacturer>> GetManufacturersAsync();
        Task<PaginatedResult<Model>> GetByManufacturerAsync(int manufacturerId, int page = 1, int languageId = 4);
        Task<ICollection<TypeEngineBusinessModel>> GetByModelAsync(int modelId, int languageId);
        Task<ManufacturerModelsBusinessModel> GetByManufacturerAndYearAsync(int manufacturerId, int yearBetween, int languageId = 4);
    }
}