
using System.ComponentModel.DataAnnotations;

namespace cic_subscription_backend.Models.LocationModels
{
    public class City
    {
        [Key]
        public long Id { get; set; }

        public long RegionId { get; set; }

        [Required]
        public string CityName { get; set; }

        public Region region { get; set; }
    }
}