using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizlet.Infrastructure.Data.Models.Auth;

namespace Quizlet.Infrastructure.Data;

public class QuizletContext : IdentityDbContext<ApplicationUser>
{
    public QuizletContext(DbContextOptions<QuizletContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
