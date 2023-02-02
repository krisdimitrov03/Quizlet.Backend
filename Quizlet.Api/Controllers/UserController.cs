using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Constants;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Services;

namespace Quizlet.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUserService userService;

        public UserController(
            IUserService _userService,
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = signInManager;
            this.userService = _userService;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new {Message = "data validation failed"});
            }

            var (status, errors) = await userService.RegisterUser(model);

            if (status == "success")
                return Ok(new { Status = status });
            else
                return BadRequest(new {Status = "failed", Errors = errors});
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginModel model) => Ok();

        [HttpGet(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("success");
        }

        [HttpGet("All")]
        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> GetAll() => Ok();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => Ok();
    }
}
