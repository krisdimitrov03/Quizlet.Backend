using Quizlet.Infrastructure.Data.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizlet.Infrastructure.Data.Models
{
    public class Quiz
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; }

        [Required]
        public string ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public Image Image { get; set; }

        public IList<Question> Questions { get; set; }
    }
}