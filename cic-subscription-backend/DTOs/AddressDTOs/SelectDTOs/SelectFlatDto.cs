using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs
{
    public class SelectFlatDto
    {
        public long Id { get; set; }

        public long CityId { get; set; }

        public long? VillageId { get; set; }

        public long? FloorId { get; set; }

        public long? ApartmentId { get; set; }

        public long StreetId { get; set; }

        public string HouseName { get; set; }

        public string FloorName { get; set; }

        public string ApartmentName { get; set; }

        public string StreetName { get; set; }

        public string VillageName { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }
    }
}
