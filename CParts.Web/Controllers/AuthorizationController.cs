using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Internal;
using CParts.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CParts.Web.Controllers
{
    [Route("api/v1/auth")]
    public class AuthorizationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var credentials = new SigningCredentials(GenerateKey(), SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            var token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: credentials
            );

            return new JsonMessageResult("Ok", 200, new {token = new JwtSecurityTokenHandler().WriteToken(token)});
        }

        public SecurityKey GenerateKey()
        {
            var key = "hmac231sldjpoapo3i42pk234lk2kl3lkjl6jlj34kjpou2v4k7jh";
            var st = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(st);
            return securityKey;
        }
    }
}