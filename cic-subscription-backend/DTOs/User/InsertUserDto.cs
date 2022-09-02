using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscriptions_backend.Dtos.user
{
    public class InsertUserDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }


        public DateTime SubscriptionDate { get; set; }

        public string Address { get; set; }

        public string AddressDescription { get; set; }

        public float Debt { get; set; }

        public int SubscriptionTypeId { get; set; }
    }
}