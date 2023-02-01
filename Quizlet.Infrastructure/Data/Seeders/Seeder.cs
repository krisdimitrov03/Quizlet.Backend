using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quizlet.Infrastructure.Data.Models.Auth;

namespace Quizlet.Infrastructure.Data.Seeders
{
    public static class Seeder
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QuizletContext>();

                context.Database.EnsureCreated();

                AddData<ApplicationUser>(context, DataConstants.Users);
            }
        }

        private static void AddData<T>(QuizletContext context, string fileName)
            where T : class
        {
            if (!context.Set<T>().Any())
            {
                var data = new List<T>();

                using (var reader = new StreamReader(string.Format(DataConstants.Path, fileName)))
                {
                    data = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
                }

                context.Set<T>().AddRange(data);
                context.SaveChanges();
            }
        }
    }
}
