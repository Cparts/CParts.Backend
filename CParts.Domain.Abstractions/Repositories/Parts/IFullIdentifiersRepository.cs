using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Parts.Additional;

namespace CParts.Domain.Abstractions.Repositories.Parts
{
    public interface IFullIdentifiersRepository : IReadRepository<FullTypeIdentifier>
    {
        Task<object> SearchByQueryAsync(string sookablyat);
    }
}