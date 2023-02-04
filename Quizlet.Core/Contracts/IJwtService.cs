using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IJwtService
    {
        string GenerateToken(TokenData data, AppSettings settings);
    }
}
