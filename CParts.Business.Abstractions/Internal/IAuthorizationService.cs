using System.Threading.Tasks;
using CParts.Domain.Core.Model.Internal;
using Microsoft.AspNetCore.Identity;

namespace CParts.Business.Abstractions.Internal
{
    public interface IAuthorizationService
    {
        Task<IdentityResult> ChangePasswordAsync(string email, string oldPassword, string newPassword);
        Task<IdentityResult> RegisterUserAsync(ApplicationUser newUser, string password);
        Task<string> GenerateAndSendPasswordResetTokenAsync(string email);
        Task<string> TryLoginAndGenerateTokenAsync(string email, string password, bool isPersistant);
    }
}