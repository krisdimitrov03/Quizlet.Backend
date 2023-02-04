using System.ComponentModel.DataAnnotations;

namespace Quizlet.Infrastructure.Data.Models
{
    public class Image
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(64)]
        public string Url { get; set; }
    }
}