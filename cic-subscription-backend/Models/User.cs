
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cic_subscriptions_backend.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime SubscriptionDate { get; set; }
        [Required]
        public string Address { get; set; }

        public string AddressDescription { get; set; }
        [Required]
        public float Debt { get; set; }

        public long SubscriptionTypeId { get; set; }

        public SubscriptionType fkSubs { get; set; }
    }
}