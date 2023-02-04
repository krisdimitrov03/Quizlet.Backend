using System.ComponentModel.DataAnnotations;

namespace Quizlet.Infrastructure.Data.Models
{
    public class Gender
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(6)]
        public string Name { get; set; }
    }
}
