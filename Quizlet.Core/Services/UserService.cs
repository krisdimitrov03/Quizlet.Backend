using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Models.User;
using Quizlet.Infrastructure.Data.Models.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtService jwtService;

        public UserService(IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IJwtService _jwtService)
        {
            this.repo = _repo;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.jwtService = _jwtService;
        }

        public async Task<(bool, string[])> RegisterUser(RegisterModel data)
        {
            // TODO
            return (true, new string[0]);
        }

        public async Task<(bool, string)> LogUserIn(LoginModel data)
        {
            var result = await signInManager.PasswordSignInAsync(data.Username, data.Password, false, false);

            if(!result.Succeeded)
                return (false, string.Empty);

            var user = await userManager.FindByNameAsync(data.Username);
            var roles = await userManager.GetRolesAsync(user);

            var token = await jwtService.GenerateToken(user.UserName, roles.ToArray());

            return (true, token);
        }

        private async Task<ApplicationUser[]> GetAll()
        {
            return await repo
                .All<ApplicationUser>()
                .ToArrayAsync();
        }

        public async Task<UserInTableModel[]> GetUsersInTable()
        {
            var users = await GetAll();

            return users
                .Select(x => new UserInTableModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                })
                .ToArray();
        }
    }
}
