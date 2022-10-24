using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.MainDTOs
{
    public class SelectUserDto
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

        public long? ApartmentId { get; set; }

        public long? FloorId { get; set; }

        public long? FlatId { get; set; }

        public string RegionName { get; set; }

        public string CityName { get; set; }

        public string VillageName { get; set; }

        public string StreetName { get; set; }

        public string HouseName { get; set; }

        public string ApartmentName { get; set; }

        public string FloorName { get; set; }
    }
}
