using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IJwtService
    {
        Task<string> GenerateToken(string username, string password, string[] roles);
    }
}
