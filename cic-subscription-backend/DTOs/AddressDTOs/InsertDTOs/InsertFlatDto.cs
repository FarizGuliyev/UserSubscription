using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs
{
    public class InsertFlatDto
    {
        public long Id { get; set; }

        public long StreetId { get; set; }

        public long? ApartmentId { get; set; }

        public long? FloorId { get; set; }

        public string HouseName { get; set; }
    }
}
