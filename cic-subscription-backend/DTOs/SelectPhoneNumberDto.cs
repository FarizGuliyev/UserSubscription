using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscription_backend.DTOs
{
    public class SelectPhoneNumberDto
    {
        public long Id { get; set; }

         public long UserId { get; set; }

         public string UserName{get;set;}
        
        public string Number { get; set; }

    }
}