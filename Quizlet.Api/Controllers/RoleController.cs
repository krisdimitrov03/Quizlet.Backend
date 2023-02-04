using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Constants;
using Quizlet.Core.Models.Role;

namespace Quizlet.Api.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    public class RoleController : BaseController
    {
        [HttpPost("Create/{roleName}")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            return Ok();
        }

        [HttpPost("Delete/{roleName}")]
        public async Task<IActionResult> DeleteRole([FromBody] string roleName)
        {
            return Ok();
        }

        [HttpPost("Change")]
        public async Task<IActionResult> ChangeUserRoles([FromBody] ChangeUserRolesModel data)
        {
            return Ok();
        }
    }
}
