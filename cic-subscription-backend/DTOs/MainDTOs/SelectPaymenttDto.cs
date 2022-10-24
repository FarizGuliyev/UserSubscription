using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs
{
    public class SelectPaymenttDto
    {
        public string UserName { get; set; }
        public float? ProductAmount { get; set; }
        public float PaymentAmount { get; set; }
        public string PaymentDate { get; set; }
        public float Debt { get; set; }
    }
}