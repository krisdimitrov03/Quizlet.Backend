using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Models.User;
using Quizlet.Infrastructure.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IUserService
    {
        Task<(bool, string[])> RegisterUser(RegisterModel data);

        Task<(bool, string)> LogUserIn(LoginModel data);

        Task<UserInTableModel[]> GetUsersInTable();
    }
}
