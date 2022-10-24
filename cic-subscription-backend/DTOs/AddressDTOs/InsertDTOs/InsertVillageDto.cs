using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs
{
    public class InsertVillageDto
    {
         public long Id { get; set; }

        public long CityId { get; set; }
        
        public string VillageName { get; set; }
    }
}