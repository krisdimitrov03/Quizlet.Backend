using System.Configuration;

namespace Quizlet.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("QuizletContextConnection");

        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfiguration = configuration.GetSection(nameof(AppSettings));
            services.Configure<AppSettings>(appSettingsConfiguration);

            return appSettingsConfiguration.Get<AppSettings>();
        }
    }
}
