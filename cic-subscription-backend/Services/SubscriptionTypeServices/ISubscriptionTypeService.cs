using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.SubscriptionTypeServices
{
    public interface ISubscriptionTypeService
    {
        public Task<SubscriptionType> InsertSubscriptionType(InsertSubscriptionTypeDto subscriptionTypeDto);

        public Task<List<SubscriptionType>> SelectSubscriptionTypes();

        public Task<SubscriptionType> SelectSubsById(long userId);

        public Task<SubscriptionType> UpdateSubscriptionType(long id, InsertSubscriptionTypeDto subscriptionTypeDto);

        public Task<SubscriptionType> RemoveSubscriptionType(long id);
    }
}