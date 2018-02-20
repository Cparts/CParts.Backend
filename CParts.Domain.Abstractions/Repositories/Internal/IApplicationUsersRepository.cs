using System.Threading.Tasks;
using CParts.Domain.Abstractions.Repositories.Base;
using CParts.Domain.Core.Model.Internal;

namespace CParts.Domain.Abstractions.Repositories.Internal
{
    public interface IApplicationUsersRepository : ICrudRepository<ApplicationUser, string>
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
    }
}