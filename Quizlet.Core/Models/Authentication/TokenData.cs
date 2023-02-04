using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Authentication
{
    public class TokenData
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Roles { get; set; }
    }
}
