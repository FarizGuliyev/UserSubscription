using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs
{
    public class InsertApartmentDto
    {
        public long Id { get; set; }

        public long StreetId { get; set; }

        public string ApartmentName { get; set; }
    }
}