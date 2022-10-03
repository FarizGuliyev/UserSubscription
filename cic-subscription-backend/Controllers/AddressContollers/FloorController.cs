using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscription_backend.Services.AddressServices.FloorServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class FloorController : ControllerBase
    {
        private IFloorService service;
        private readonly DatabaseContext context;

        public FloorController(DatabaseContext context, IFloorService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Floor>> PostFloor(Floor floor)
        {
            return Ok(await service.InsertFloor(floor));
        }

        [HttpGet]
        public async Task<List<Floor>> GetFloors()
        {
            List<Floor> models = await service.SelectFloors();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<Floor> PutFloor(long id, Floor floor)
        {
            Floor model = await service.UpdateFloor(id, floor);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Floor> DeleteFloor(long id)
        {
            Floor floor = await service.RemoveFloor(id);
            return floor;
        }
    }
}