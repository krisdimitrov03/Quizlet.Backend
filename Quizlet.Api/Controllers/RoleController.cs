using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Constants;
using Quizlet.Core.Models.Return;
using Quizlet.Core.Models.Role;
using Quizlet.Infrastructure.Data.Models.Identity;

namespace Quizlet.Api.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    public class RoleController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager)
        {
            this.roleManager = _roleManager;
            this.userManager = _userManager;
        }

        [HttpPost("Create/{roleName}")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            try
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });

                return CreatedAtAction(nameof(CreateRole),
                    new SuccessReturnModel());
            }
            catch (Exception)
            {
                return BadRequest(new FailReturnModel());
            }
        }

        [HttpPost("Delete/{roleName}")]
        public async Task<IActionResult> DeleteRole([FromBody] string roleName)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(roleName);
                await roleManager.DeleteAsync(role);

                return Ok(new SuccessReturnModel());
            }
            catch (Exception)
            {
                return NotFound(new FailReturnModel());
            }

        }

        [HttpPost("Change")]
        public async Task<IActionResult> ChangeUserRoles([FromBody] ChangeUserRolesModel data)
        {
            try
            {
                var user = await userManager.FindByIdAsync(data.UserId);
                var roles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, roles);
                await userManager.AddToRolesAsync(user, data.Roles);

                return Ok(new SuccessReturnModel());
            }
            catch (Exception)
            {
                return Ok(new FailReturnModel());
            }
        }
    }
}
