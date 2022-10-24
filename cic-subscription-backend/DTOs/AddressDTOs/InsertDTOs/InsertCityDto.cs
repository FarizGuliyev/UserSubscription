using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs
{
    public class InsertCityDto
    {
        public long Id { get; set; }

        public long RegionId { get; set; }

        public string CityName { get; set; }
    }
}