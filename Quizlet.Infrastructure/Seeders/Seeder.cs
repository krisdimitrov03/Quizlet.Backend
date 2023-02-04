using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quizlet.Infrastructure.Data;
using Quizlet.Infrastructure.Data.Models;
using Quizlet.Infrastructure.Data.Models.Identity;

namespace Quizlet.Infrastructure.Seeders
{
    public static class Seeder
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QuizletAPIContext>();

                context.Database.EnsureCreated();

                AddData<Gender>(context, DataConstants.Genders);
                AddData<ApplicationUser>(context, DataConstants.Users);
                AddData<Quiz>(context, DataConstants.Quizes);
            }

            return builder;
        }

        private static void AddData<T>(QuizletAPIContext context, string fileName)
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
