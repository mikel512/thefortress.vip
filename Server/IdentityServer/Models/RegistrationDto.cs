﻿using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RegistrationDto
    {
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
