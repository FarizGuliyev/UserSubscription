using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.SubscriptionTypeServices
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private DatabaseContext context;
        private IMapper mapping;
        public SubscriptionTypeService(DatabaseContext databaseContext, IMapper autoMapping)
        {
            context = databaseContext;
            mapping = autoMapping;
        }

        public async Task<SubscriptionType> InsertSubscriptionType(InsertSubscriptionTypeDto subscriptionTypeDto)
        {
            var subscriptionType = mapping.Map<SubscriptionType>(subscriptionTypeDto);
            await context.SubscriptionType.AddAsync(subscriptionType);
            await context.SaveChangesAsync();
            return subscriptionType;
        }

        public async Task<List<SubscriptionType>> SelectSubscriptionTypes()
        {
            List<SubscriptionType> subs = await context.SubscriptionType.ToListAsync();
            return subs;
        }


        public async Task<SubscriptionType> UpdateSubscriptionType(long id, InsertSubscriptionTypeDto subscriptionTypeDto)
        {
            if (id != subscriptionTypeDto.Id)
            {
                throw new NotImplementedException();
            }
            var foundsubscriptionType = await context.SubscriptionType.FindAsync(id);

            if (foundsubscriptionType == null)
            {
                throw new NotImplementedException();
            }

            var updateSubscriptionType = mapping
            .Map<InsertSubscriptionTypeDto, SubscriptionType>(subscriptionTypeDto, foundsubscriptionType);

            context.Entry(foundsubscriptionType).CurrentValues.SetValues(subscriptionTypeDto);
            await context.SaveChangesAsync();
            return foundsubscriptionType;
        }

        public async Task<SubscriptionType> RemoveSubscriptionType(long id)
        {
            SubscriptionType foundSubscriptionType = await context.SubscriptionType.FindAsync(id);

            if (foundSubscriptionType == null)
            {
                throw new NotImplementedException();
            }

            context.SubscriptionType.Remove(foundSubscriptionType);
            await context.SaveChangesAsync();

            return foundSubscriptionType;
        }


    }
}