﻿using System.ComponentModel.DataAnnotations;

namespace Quizlet.Core.Models.Authentication
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
