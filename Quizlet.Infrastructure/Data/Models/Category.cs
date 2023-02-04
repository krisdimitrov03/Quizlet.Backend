using System.ComponentModel.DataAnnotations;

namespace Quizlet.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}