﻿using System.ComponentModel.DataAnnotations;

namespace KRWTransfer.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
