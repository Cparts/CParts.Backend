using System.Threading.Tasks;
using CParts.Services.Abstractions.Internal.ViewModels;
using CParts.Services.Abstractions.Internal.ViewModels.Results;

namespace CParts.Services.Abstractions.Internal
{
    public interface IAuthorizationServiceMapper
    {
        Task<SignInResultViewModel> LoginAndGenerateTokenAsync(SignInViewModel model);
        Task<RegistrationResultViewModel> RegisterUserAsync(RegisterViewModel model);
    }
}