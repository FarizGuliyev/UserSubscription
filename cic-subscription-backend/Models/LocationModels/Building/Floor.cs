using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.Models.LocationModels.Building
{
    public class Floor
    {
        [Key]
        public long Id { get; set; }

        public long ApartmentId { get; set; }

        public string Name { get; set; }

    public Apartment fkApartment { get; set; }
}
}