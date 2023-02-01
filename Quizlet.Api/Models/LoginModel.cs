﻿using System.ComponentModel.DataAnnotations;

namespace Quizlet.Api.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
