using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.Models.LocationModels
{
    public class Street
    {
        [Key]
        public long Id { get; set; }

        public long CityId { get; set; }

        public long? VillageId { get; set; }

        [Required]
        public string StreetName { get; set; }

        public City city { get; set; }

        public virtual Village village { get; set; }
    }
}
