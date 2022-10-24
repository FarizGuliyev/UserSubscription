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

        public float Debt { get; set; }

        public long? SubscriptionTypeId { get; set; }

        public long? RegionId { get; set; }

        public long? CityId { get; set; }

        public long? VillageId { get; set; }

        public long? StreetId { get; set; }

        public long? FlatId { get; set; }

        public long? ApartmentId { get; set; }

        public long? FloorId { get; set; }

    }
}
