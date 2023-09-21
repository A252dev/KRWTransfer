using System.ComponentModel.DataAnnotations;

namespace KRWTransfer.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FromUsername { get; set; }
        [Required]
        public string? ToUsername { get; set; }
        [Required]
        public int Coins { get; set; }
    }
}
