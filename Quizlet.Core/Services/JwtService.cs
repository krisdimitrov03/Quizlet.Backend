using Quizlet.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateToken(string username, string password, string[] roles)
        {
            return "token";
        }
    }
}
