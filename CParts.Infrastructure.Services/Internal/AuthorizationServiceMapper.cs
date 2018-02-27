using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Internal;
using CParts.Domain.Core.Model.Internal;
using CParts.Services.Abstractions.Internal;
using CParts.Services.Abstractions.Internal.ViewModels;
using CParts.Services.Abstractions.Internal.ViewModels.Results;
using Microsoft.AspNetCore.Identity;

namespace CParts.Infrastructure.Services.Internal
{
    public class AuthorizationServiceMapper : IAuthorizationServiceMapper
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationServiceMapper(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<SignInResultViewModel> LoginAndGenerateTokenAsync(SignInViewModel model)
        {
            var persistanceFlag = model.IsPersistant;
            var email = model.Email;
            var password = model.Password;

            var token = await _authorizationService.TryLoginAndGenerateTokenAsync(email, password, persistanceFlag);

            if (token == null)
            {
                return SignInResultViewModel.Failed();
            }

            return SignInResultViewModel.Succeed(token);
        }

        public async Task<RegistrationResultViewModel> RegisterUserAsync(RegisterViewModel model)
        {
            //TODO: Change model to entity convertation logic
            var newUser = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var registrationResult = await _authorizationService.RegisterUserAsync(newUser, model.Password);

            if (!registrationResult.Succeeded)
            {
                var errors = string.Join(",",
                    ((IEnumerable<IdentityError>) registrationResult.Errors).Select(x => x.Description));
                return RegistrationResultViewModel.Failed(errors);
            }

            return RegistrationResultViewModel.Successful();
        }

        public async Task<ResetPasswordResultViewModel> SendPasswordResetLinkAsync(ForgottenPasswordViewModel model)
        {
            var isSuccessful = await _authorizationService.GenerateAndSendPasswordResetTokenAsync(model.Email);
            return new ResetPasswordResultViewModel
            {
                Success = isSuccessful
            };
        }

        public async Task<ChangePasswordResultViewModel> ChangeUsersPasswordAsync(PasswordChangeViewModel model, ApplicationUser user)
        {
            var passwordChangeResult =
                await _authorizationService.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);


            string errors = null;
            if (!passwordChangeResult.Succeeded)
            {
                errors = string.Join(",",
                    ((IEnumerable<IdentityError>) passwordChangeResult.Errors).Select(x => x.Description));
            }

            return new ChangePasswordResultViewModel
            {
                Success = passwordChangeResult.Succeeded,
                Message = passwordChangeResult.Succeeded ? "Successfuly changed password" : errors
            };
        }
    }
}