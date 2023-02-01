using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Api.Models;
using Quizlet.Core.Constants;

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

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel model) => Ok();

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginModel model) => Ok();

        [HttpGet(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("success");
        }

        [HttpGet("all")]
        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> GetAll() => Ok();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => Ok();
    }
}
