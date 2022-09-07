using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cic_subscriptions_backend.Models
{
    public class PhoneNumber
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }
        [Required]
        public string Number { get; set; }
        public User user { get; set; }
    }
}