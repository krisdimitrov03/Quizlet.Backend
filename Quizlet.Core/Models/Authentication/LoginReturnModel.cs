using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Authentication
{
    public class LoginReturnModel : AuthReturnModel
    {
        public string Token { get; set; }
    }
}
