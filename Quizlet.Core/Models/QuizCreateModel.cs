using Quizlet.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models
{
    public class QuizCreateModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string CreatorId { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public IList<Question> Questions { get; set; }
    }
}
