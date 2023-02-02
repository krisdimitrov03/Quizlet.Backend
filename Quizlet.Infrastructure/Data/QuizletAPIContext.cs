using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizlet.Infrastructure.Data.Models.Identity;

namespace Quizlet.Infrastructure.Data;

public class QuizletAPIContext : IdentityDbContext<ApplicationUser>
{
    public QuizletAPIContext(DbContextOptions<QuizletAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
