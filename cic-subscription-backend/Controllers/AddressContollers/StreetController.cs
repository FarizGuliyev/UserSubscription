using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;
using cic_subscription_backend.Services.AddressServices.StreetServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class StreetController : ControllerBase
    {
        private IStreetService service;
        private readonly DatabaseContext context;

        public StreetController(DatabaseContext context, IStreetService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Street>> PostStreet(Street street)
        {
            return Ok(await service.InsertStreet(street));
        }

        [HttpGet]
        public async Task<List<Street>> GetStreets()
        {
            List<Street> models = await service.SelectStreets();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<Street> PutStreet(long id, Street street)
        {
            Street model = await service.UpdateStreet(id, street);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Street> DeleteStreet(long id)
        {
            Street street = await service.RemoveStreet(id);
            return street;
        }
    }
}