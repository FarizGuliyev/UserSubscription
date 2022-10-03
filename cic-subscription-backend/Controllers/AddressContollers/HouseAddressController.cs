using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.House;
using cic_subscription_backend.Services.AddressServices.HouseAddressServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class HouseAddressController:ControllerBase
    {
         private IHouseAddressService service;
        private readonly DatabaseContext context;

        public HouseAddressController(DatabaseContext context, IHouseAddressService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<HouseAddress>> PostHouseAddress(HouseAddress houseAddress)
        {
            return Ok(await service.InsertHouseAddress(houseAddress));
        }

        [HttpGet]
        public async Task<List<HouseAddress>> GetHouseAddress()
        {
            List<HouseAddress> models = await service.SelectHouseAddress();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<HouseAddress> PutHouseAddress(long id, HouseAddress houseAddress)
        {
            HouseAddress model = await service.UpdateHouseAddress(id, houseAddress);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<HouseAddress> DeleteHouseAddress(long id)
        {
            HouseAddress houseAddress = await service.RemoveHouseAddress(id);
            return houseAddress;
        }
    }
}