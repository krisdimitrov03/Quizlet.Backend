using Quizlet.Core.Contracts;
using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<(string, string[])> RegisterUser(RegisterModel data)
        {
            return ("success", new string[0]);
        }
    }
}
