using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KRWTransfer.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public int Balance { get; set; }
    }
}
