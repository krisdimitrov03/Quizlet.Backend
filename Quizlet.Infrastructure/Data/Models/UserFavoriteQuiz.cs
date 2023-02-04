using Quizlet.Infrastructure.Data.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizlet.Infrastructure.Data.Models
{
    public class UserFavoriteQuiz
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string QuizId { get; set; }

        [ForeignKey(nameof(QuizId))]
        public Quiz Quiz { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
