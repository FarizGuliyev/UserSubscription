using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscription_backend.Services.SubscriptionTypeServices;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers
{

    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionTypeController : ControllerBase
    {
        private ISubscriptionTypeService service;
        private readonly DatabaseContext context;

        public SubscriptionTypeController(DatabaseContext context, ISubscriptionTypeService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionType>> PostSubscriptionType(InsertSubscriptionTypeDto subscriptionTypeDto)
        {
            return Ok(await service.InsertSubscriptionType(subscriptionTypeDto));
        }

        [HttpGet]
        public async Task<List<SubscriptionType>> GetSubscriptionTypes()
        {
            List<SubscriptionType> models = await service.SelectSubscriptionTypes();
            return models;
        }


       
        [HttpPut("{id}")]
        public async Task<SubscriptionType> PutSubscriptionType(long id, InsertSubscriptionTypeDto subscriptionTypeDto)
        {
            SubscriptionType subscriptionType = await service.UpdateSubscriptionType(id, subscriptionTypeDto);
            return subscriptionType;
        }

        [HttpDelete("{id}")]
        public async Task<SubscriptionType> DeleteSubscriptionType(long id)
        {
            SubscriptionType subscriptionType = await service.RemoveSubscriptionType(id);
            return subscriptionType;
        }
    }
}