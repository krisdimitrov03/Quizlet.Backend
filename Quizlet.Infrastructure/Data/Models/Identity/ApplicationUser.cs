using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizlet.Infrastructure.Data.Models.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    public string ImageId { get; set; }

    [ForeignKey(nameof(ImageId))]
    public Image Image { get; set; }

    [Required]
    public int GenderId { get; set; }

    [ForeignKey(nameof(GenderId))]
    public Gender Gender { get; set; }

    [Required]
    public int TotalPoints { get; set; }

    public IList<Quiz> Favourites { get; set; }
}

