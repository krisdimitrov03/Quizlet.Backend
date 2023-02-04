using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizlet.Infrastructure.Data.Models
{
    public class Question
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        public string QuizId { get; set; }

        [ForeignKey(nameof(QuizId))]
        public Quiz Quiz { get; set; }

        [Required]
        [Range(1, 10)]
        public int Points { get; set; }

        [Required]
        public IList<QuestionOption> Options { get; set; }
    }
}
