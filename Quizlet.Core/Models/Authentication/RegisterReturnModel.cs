using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Authentication
{
    public class RegisterReturnModel : AuthReturnModel
    {
        public string[] Errors { get; set; }
    }
}
