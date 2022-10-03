using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscription_backend.Services.AddressServices.ApartmentServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentController : ControllerBase
    {
        private IApartmentService service;
        private readonly DatabaseContext context;

        public ApartmentController(DatabaseContext context, IApartmentService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartment(Apartment apartment)
        {
            return Ok(await service.InsertApartment(apartment));
        }

        [HttpGet]
        public async Task<List<Apartment>> GetApartments()
        {
            List<Apartment> models = await service.SelectApartments();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<Apartment> PutApartment(long id, Apartment apartment)
        {
            Apartment model = await service.UpdateApartment(id, apartment);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Apartment> DeleteApartment(long id)
        {
            Apartment apartment = await service.RemoveApartment(id);
            return apartment;
        }
    }
}