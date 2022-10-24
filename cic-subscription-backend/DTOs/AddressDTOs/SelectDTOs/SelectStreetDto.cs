using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs
{
    public class SelectStreetDto
    {
        public long Id { get; set; }

        public long CityId { get; set; }

        public long? VillageId { get; set; }

        public string StreetName { get; set; }

        public string VillageName { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }
    }
}
