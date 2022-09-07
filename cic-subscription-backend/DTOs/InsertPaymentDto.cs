using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs
{
    public class InsertPaymentDto
    {
         public long Id { get; set; }

        public long UserId { get; set; }
        
        public float Amount { get; set; }
       
        public string Type { get; set; }
        
        
        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}