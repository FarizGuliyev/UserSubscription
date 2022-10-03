using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.Models
{
    public class Region
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}