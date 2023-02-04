using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Authentication;
using Quizlet.Core.Models.User;
using Quizlet.Core.Settings;
using Quizlet.Infrastructure.Data.Models.Identity;
using Quizlet.Infrastructure.Data.Repositories;

namespace Quizlet.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtService jwtService;
        private readonly AppSettings appSettings;

        public UserService(IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IJwtService _jwtService,
            IOptions<AppSettings> _appSettings)
        {
            this.repo = _repo;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.jwtService = _jwtService;
            this.appSettings = _appSettings.Value;
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

            var tokenData = new TokenData
            {
                UserId = user.Id,
                Username = user.UserName,
                Roles = string.Join(", ", roles)
            };

            var token = await jwtService.GenerateToken(tokenData, appSettings);

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
