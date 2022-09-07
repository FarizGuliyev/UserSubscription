using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.DTOs
{
    public class InsertPhoneNumberDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Number { get; set; }

        
    }
}