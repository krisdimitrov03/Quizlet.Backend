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
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IUserEmailStore<ApplicationUser> emailStore;
        private readonly IJwtService jwtService;
        private readonly AppSettings appSettings;

        public UserService(IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IUserStore<ApplicationUser> _userStore,
            IJwtService _jwtService,
            IOptions<AppSettings> _appSettings)
        {
            this.repo = _repo;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.userStore = _userStore;
            this.emailStore = GetEmailStore();
            this.jwtService = _jwtService;
            this.appSettings = _appSettings.Value;
        }

        public async Task<(bool, string[])> RegisterUser(RegisterModel data)
        {
            var user = Activator.CreateInstance<ApplicationUser>();

            await userStore.SetUserNameAsync(user, data.Username, CancellationToken.None);
            await emailStore.SetEmailAsync(user, data.Email, CancellationToken.None);

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.GenderId = data.GenderId;

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
                return (true, new string[0]);

            var errors = result.Errors
                .Select(e => e.Description)
                .ToArray();

            return (false, errors);
        }

        public async Task<(bool, string)> LogUserIn(LoginModel data)
        {
            var result = await signInManager.PasswordSignInAsync(data.Username, data.Password, false, false);

            if (!result.Succeeded)
                return (false, string.Empty);

            var user = await userManager.FindByNameAsync(data.Username);
            var roles = await userManager.GetRolesAsync(user);

            var tokenData = new TokenData
            {
                UserId = user.Id,
                Username = user.UserName,
                Roles = string.Join(", ", roles)
            };

            var token = jwtService.GenerateToken(tokenData, appSettings);

            return (true, token);
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

        // Helper Functions Below

        private async Task<ApplicationUser[]> GetAll()
        {
            return await repo
                .All<ApplicationUser>()
                .ToArrayAsync();
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)userStore;
        }
    }
}
