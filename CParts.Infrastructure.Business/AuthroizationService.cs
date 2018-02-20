using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CParts.Business.Abstractions;
using CParts.Domain.Abstractions.Repositories.Internal;
using CParts.Domain.Core.Model.Internal;
using CParts.Framework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Tokens;

namespace CParts.Infrastructure.Business
{
    public class AuthroizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IApplicationUsersRepository _applicationUsersRepository;

        //TODO: Find way to avoid injecting of services into services
//        private readonly IEmailService _emailService;
        private readonly JwtSettings _jwtSettings;

        public AuthroizationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IApplicationUsersRepository applicationUsersRepository,
            IOptions<JwtSettings> jwtSettingsWrapper)
            //,IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUsersRepository = applicationUsersRepository;
//            _emailService = emailService;
            _jwtSettings = jwtSettingsWrapper.Value;
        }

        public async Task<IdentityResult> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await _applicationUsersRepository.GetByEmailAsync(email);
            var identityResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            return identityResult;
        }

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser newUser, string password)
        {
            var identityResult = await _userManager.CreateAsync(newUser, password);

            return identityResult;
        }

        public async Task<string> GenerateAndSendPasswordResetTokenAsync(string email)
        {
            var user = await _applicationUsersRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //TODO: Mock thing. Will be changed in future
            //var result = await _emailService.SendAsync(email, token);
            return token;
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