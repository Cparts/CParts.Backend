using System.Collections.Generic;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories;
using CParts.Domain.Core.Model;
using CParts.Services.Abstractions;

namespace CParts.Infrastructure.Business
{
    public class ManufacturersService : IManufacturersService
    {
        private readonly IReadRepository<Manufacturer> _manufacturersRepository;

        public ManufacturersService(IReadRepository<Manufacturer> manufacturersRepository)
        {
            _manufacturersRepository = manufacturersRepository;
        }

        public async Task<ICollection<Manufacturer>> GetAll()
        {
            return await _manufacturersRepository.AllAsync();
        }
    }
}