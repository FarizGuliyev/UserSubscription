using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;
using cic_subscription_backend.Services.AddressServices.CityServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService service;
        private readonly DatabaseContext context;

        public CityController(DatabaseContext context, ICityService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            return Ok(await service.InsertCity(city));
        }

        [HttpGet]
        public async Task<List<City>> GetCities()
        {
            List<City> models = await service.SelectCities();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<City> PutCity(long id, City city)
        {
            City model = await service.UpdateCity(id, city);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<City> DeleteCity(long id)
        {
            City city = await service.RemoveCity(id);
            return city;
        }
    }
}