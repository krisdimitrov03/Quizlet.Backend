using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Api.Models;

namespace Quizlet.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> signInManager)
        {
            userManager = _userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) => Ok();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model) => Ok();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("success");
        }
    }
}
