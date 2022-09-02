
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cic_subscriptions_backend.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime SubscriptionDate { get; set; }

        public string Address { get; set; }

        public string AddressDescription { get; set; }

        public float Debt { get; set; }

        public int SubscriptionTypeId { get; set; }
    }
}