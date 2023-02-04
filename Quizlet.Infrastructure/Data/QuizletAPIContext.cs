using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizlet.Infrastructure.Data.Models;
using Quizlet.Infrastructure.Data.Models.Identity;

namespace Quizlet.Infrastructure.Data;

public class QuizletAPIContext : IdentityDbContext<ApplicationUser>
{
    public QuizletAPIContext(DbContextOptions<QuizletAPIContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<Quiz> Quizes { get; set; }
    public DbSet<UserFavoriteQuiz> UsersFavoriteQuizes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
