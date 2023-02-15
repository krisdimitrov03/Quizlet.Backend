using Quizlet.Core.Models.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Authentication
{
    public class LoginReturnModel : ReturnModel
    {
        public LoginReturnModel(bool success, string token) 
            : base(success)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}
