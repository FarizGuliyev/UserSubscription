using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.Models.LocationModels.Building
{
    public class Apartment
    {
          [Key]
        public long Id { get; set; }

        public long StreetId { get; set; }

        public string Name { get; set; }

        public Street fkStreet { get; set; }
    }
}