using Quizlet.Core.Models.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Authentication
{
    public class RegisterReturnModel : ReturnModel
    {
        public RegisterReturnModel(bool success, string[] errors) 
            : base(success)
        {
            this.Errors = errors;
        }

        public string[] Errors { get; set; }
    }
}
