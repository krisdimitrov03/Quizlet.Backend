using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Constants;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Authentication;
using Quizlet.Infrastructure.Data.Models.Identity;

namespace Quizlet.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService service;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUserService _service,
            SignInManager<ApplicationUser> _signInManager)
        {
            this.service = _service;
            this.signInManager = _signInManager;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    Message = MessageConstants.ErrorMessages.ModelStateValidationFailure
                });

            var (success, errors) = await service.RegisterUser(model);

            var response = new RegisterReturnModel
            {
                Success = success,
                Errors = errors
            };

            if (success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var (success, token) = await service.LogUserIn(model);

            var response = new LoginReturnModel
            {
                Success = success,
                Token = token
            };

            if (success)
            {
                var options = new CookieOptions() { HttpOnly = true };
                Response.Cookies.Append("Quzlet-Auth", token, options);
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet(nameof(All))]
        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> All()
        {
            var users = await service.GetUsersInTable();

            return users == null || users.Length == 0
                ? NotFound(MessageConstants.ErrorMessages.NoUsersFound)
                : Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => Ok();

        [HttpGet($"{nameof(Edit)}/{{id}}")]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {


            return Ok();
        }


    }
}
