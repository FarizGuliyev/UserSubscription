using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cic_subscriptions_backend.Models
{
    public class SubscriptionType
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string SubName { get; set; }

        [Required]
        public float Price { get; set; }

        public string Note { get; set; }

    }
}