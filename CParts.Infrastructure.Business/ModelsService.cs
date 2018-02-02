using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core.Model;
using CParts.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CParts.Infrastructure.Business
{
    public class ModelsService : IModelsService
    {
        private readonly IReadRepository<Model> _modelRepository;
        private readonly ILogger _logger;

        public ModelsService(IReadRepository<Model> modelRepository, ILoggerFactory loggerFactory)
        {
            _modelRepository = modelRepository;
            _logger = loggerFactory.CreateLogger("Model watcher");
        }

        public Task<ICollection<Model>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Model>> GetByManufacturer(int manufacturerId)
        {
            return await _modelRepository.SelectAsync(x =>
                x.Where(y => y.ManufacturerId == manufacturerId)
                    .Include(y => y.CountryDesignation)
                    .Include(y => y.CountryDesignation.DesignationText)
                    .Distinct().ToListAsync());
        }

        public async Task<ICollection<Model>> GetByManufacturerAndYear(int manufacturerId, int year)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var collection = await _modelRepository.SelectAsync(x =>
                x.Where(model => model.ManufacturerId == manufacturerId && IsPconBetween(model, year))
                    .ToListAsync());
            collection = collection.Where(model => IsPconBetween(model, year)).ToList();
            stopwatch.Stop();
            _logger.LogWarning($"Elapsed: {stopwatch.ElapsedMilliseconds}");
            return collection;
        }

        private bool IsPconBetween(Model model, int year)
        {
            if (model.PconStart == null || model.PconEnd == null)
                return false;
            var startPconYear = GetPconYear(model.PconStart.Value);
            var endPconYear = GetPconYear(model.PconEnd.Value);
            return startPconYear >= year && year <= endPconYear;
        }

        private int GetPconYear(int pcon)
        {
            int pconYear = pcon;
            pconYear = pcon / 100;
            return pconYear;
        }
    }
}