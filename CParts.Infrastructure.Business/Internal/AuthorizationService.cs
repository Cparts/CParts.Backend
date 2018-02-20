using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CParts.Business.Abstractions.Internal;
using CParts.Business.Abstractions.ThirdParty;
using CParts.Domain.Abstractions.Repositories.Internal;
using CParts.Domain.Core.Model.Internal;
using CParts.Framework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace CParts.Infrastructure.Business.Internal
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailService _emailService;
        private readonly JwtSettings _jwtSettings;

        private readonly IApplicationUsersRepository _applicationUsersRepository;

        public AuthorizationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IApplicationUsersRepository applicationUsersRepository,
            IOptions<JwtSettings> jwtSettingsWrapper, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUsersRepository = applicationUsersRepository;
            _emailService = emailService;
            _jwtSettings = jwtSettingsWrapper.Value;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword,
            string newPassword)
        {
            if (user == null)
                throw new ArgumentNullException();

            var identityResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            return identityResult;
        }

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser newUser, string password)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            var identityResult = await _userManager.CreateAsync(newUser, password);

            return identityResult;
        }

        public async Task<bool> GenerateAndSendPasswordResetTokenAsync(string email)
        {
            var user = await _applicationUsersRepository.GetByEmailAsync(email);

            if (user == null)
                return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _emailService.SendForgetPasswordTokenAsync(email, token);

            return result;
        }

        public async Task<string> TryLoginAndGenerateTokenAsync(string email, string password, bool isPersistant)
        {
            var user = await _applicationUsersRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var signInAttemp = await _signInManager.PasswordSignInAsync(user, password, isPersistant, true);

            if (!signInAttemp.Succeeded)
            {
                return null;
            }

            var token = GenerateJWT(user);
            return token;
        }

        private string GenerateJWT(ApplicationUser user)
        {
            var claims = GetUserClaims(user);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now + _jwtSettings.ExpireTime,
                signingCredentials: _jwtSettings.SigningCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedJwt;
        }

        private List<Claim> GetUserClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(),
                    ClaimValueTypes.Integer64)
            };
            return claims;
        }

        //TODO: Move this to framework
        private long ToUnixEpochDate(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
        }
    }
}