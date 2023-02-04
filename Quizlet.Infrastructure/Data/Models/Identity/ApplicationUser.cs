using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Quizlet.Infrastructure.Data.Models.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }
}

