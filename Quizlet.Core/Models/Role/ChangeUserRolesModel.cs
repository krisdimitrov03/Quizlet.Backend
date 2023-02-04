using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Role
{
    public class ChangeUserRolesModel
    {
        public string UserId { get; set; }

        public string[] Roles { get; set; }
    }
}
