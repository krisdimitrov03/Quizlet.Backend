using Quizlet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IUserService
    {
        Task<(string, string[])> RegisterUser(RegisterModel data);
    }
}
