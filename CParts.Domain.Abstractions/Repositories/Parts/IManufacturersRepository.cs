using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IManufacturersRepository : IReadRepository<Manufacturer>
    {
    }
}