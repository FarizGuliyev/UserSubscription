using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscription_backend.Services.AddressServices.FlatServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class FlatController:ControllerBase
    {
         private IFlatService service;
        private readonly DatabaseContext context;

        public FlatController(DatabaseContext context, IFlatService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Flat>> PostFlat(Flat flat)
        {
            return Ok(await service.InsertFlat(flat));
        }

        [HttpGet]
        public async Task<List<Flat>> GetFlats()
        {
            List<Flat> models = await service.SelectFlats();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<Flat> PutFlat(long id, Flat flat)
        {
            Flat model = await service.UpdateFlat(id, flat);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Flat> DeleteFlat(long id)
        {
            Flat flat = await service.RemoveFlat(id);
            return flat;
        }
    }
}