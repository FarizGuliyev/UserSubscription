using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Models.LocationModels.Building
{
    public class Flat
    {
        [Key]
        public long Id { get; set; }

        public long FloorId { get; set; }

        public string Address { get; set; }

        public Floor fkFloor { get; set; }

    }
}