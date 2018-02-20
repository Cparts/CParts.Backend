using System.Threading.Tasks;
using CParts.Domain.Core.Model.Internal;
using Microsoft.AspNetCore.Identity;

namespace CParts.Business.Abstractions.Internal
{
    public interface IAuthorizationService
    {
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword,
            string newPassword);
        Task<IdentityResult> RegisterUserAsync(ApplicationUser newUser, string password);
        Task<string> TryLoginAndGenerateTokenAsync(string email, string password, bool isPersistant);
        Task<bool> GenerateAndSendPasswordResetTokenAsync(string email);
    }
}