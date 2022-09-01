using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cic_subscriptions_backend.Models 
{
    public class User 
    {
        public int Id {get; set;}

        public string Name { get; set; }

        public string Surname {get; set;}
        
        public string FatherName {get; set;}

        public DateTime SubscriptionDate {get; set;}

        public string Adress {get; set;}

        public string AdressDescription {get; set;}

        public float Debt {get; set;}

        public int SubscriptionTypeId {get; set;}
    }
}