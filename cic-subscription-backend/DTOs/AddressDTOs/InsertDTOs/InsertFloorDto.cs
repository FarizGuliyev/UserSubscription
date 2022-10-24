using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs
{
    public class InsertFloorDto
    {
        
        public long Id { get; set; }

        public long ApartmentId { get; set; }

        public string FloorName { get; set; }
    }
}