using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.DTOs
{
    public class InsertSubscriptionTypeDto
    {
        public long Id { get; set; }

        public string SubName { get; set; }

        public float Price { get; set; }

        public string Note { get; set; }


    }
}