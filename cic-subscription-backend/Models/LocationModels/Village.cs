using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.Models.LocationModels
{
    public class Village
    {
        [Key]
        public long Id { get; set; }

        public long CityId { get; set; }

        [Required]
        public string Name { get; set; }

        public City fkCity { get; set; }
    }
}