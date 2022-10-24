using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Models.LocationModels.House
{
    public class Flat
    {
         [Key]
        public long Id { get; set; }

        public long StreetId { get; set; }
        public long? ApartmentId { get; set; }
        public long? FloorId { get; set; }

        public string HouseName { get; set; }

        public Street street { get; set; }
         public virtual Apartment apartment { get; set; }
          public virtual Floor floor { get; set; }
    }
}