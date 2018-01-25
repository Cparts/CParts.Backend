using System.Threading.Tasks;
using CParts.Domain.Core;
using CParts.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            return Ok();
        }  
    }
}