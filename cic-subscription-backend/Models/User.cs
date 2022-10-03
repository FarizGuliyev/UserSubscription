
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cic_subscription_backend.Models;
using cic_subscription_backend.Models.LocationModels;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscription_backend.Models.LocationModels.House;


namespace cic_subscriptions_backend.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime SubscriptionDate { get; set; }

        [Required]
        public float Debt { get; set; }

        public long SubscriptionTypeId { get; set; }
        public long? RegionId { get; set; }
        public long? CityId { get; set; }
        public long? VillageId { get; set; }
        public long? StreetId { get; set; }
        public long? HouseAddressId { get; set; }
        public long? ApartmentId { get; set; }
        public long? FloorId { get; set; }
        public long? FlatId { get; set; }

        public SubscriptionType fkSubs { get; set; }
        public Region fkRegion { get; set; }
        public City fkCity { get; set; }
        public Village fkVillage { get; set; }
        public Street fkStreet { get; set; }
        public HouseAddress fkHouseAddress { get; set; }
        public Apartment fkApartment { get; set; }
        public Floor fkFloor { get; set; }
        public Flat fkFlat { get; set; }

    }
}