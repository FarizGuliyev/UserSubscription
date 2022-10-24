using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs
{
    public class SelectVillageDto
    {
        public long Id { get; set; }

        public long RegionId { get; set; }

        public long CityId { get; set; }

        public string VillageName { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }
    }
}
