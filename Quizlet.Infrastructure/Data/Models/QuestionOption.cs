using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizlet.Infrastructure.Data.Models
{
    public class QuestionOption
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [Required]
        public string QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}
