using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quizlet.Core.Contracts;
using Quizlet.Core.Services;
using Quizlet.Core.Settings;
using Quizlet.Infrastructure.Data;
using Quizlet.Infrastructure.Data.Models.Identity;
using Quizlet.Infrastructure.Data.Repositories;
using System.Text;

namespace Quizlet.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserDefinedServices(this IServiceCollection services)
        => services
            .AddScoped<IApplicationDbRepository, ApplicationDbRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IJwtService, JwtService>();

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<QuizletAPIContext>(options =>
                options.UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<QuizletAPIContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}