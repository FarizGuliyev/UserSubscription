using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cic_subscriptions_backend.Models
{
    public class Payment
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime PayDate { get; set; }

        public string Note { get; set; }
        public User user { get; set; }
    }
}