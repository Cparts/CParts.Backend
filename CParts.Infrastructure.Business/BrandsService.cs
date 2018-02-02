using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core.Model;
using CParts.Services.Abstractions;

namespace CParts.Infrastructure.Business
{
    public class BrandsService : IBrandsService
    {
        private readonly IReadRepository<Brand> _brandRepository;

        public BrandsService(IReadRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ICollection<Brand>> AllAsync()
        {
            return await _brandRepository.AllAsync();
        }
    }
}