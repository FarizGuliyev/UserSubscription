using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscription_backend.Services.AddressServices.FloorServices;
using cic_subscriptions_backend.Context;

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
        public async Task<ActionResult<Floor>> PostFloor(InsertFloorDto floor)
        {
            return Ok(await service.InsertFloor(floor));
        }

        [HttpGet]
        public async Task<List<SelectFloorDto>> GetFloors()
        {
            List<SelectFloorDto> models = await service.SelectFloors();
            return models;
        }

        [HttpGet("{id}")]
        public async Task<List<SelectFloorDto>> GetFloorsById(long id)
        {
            List<SelectFloorDto> models = await service.SelectFloorsById(id);
            return models;
        }

        [HttpPut("{id}")]
        public async Task<Floor> PutFloor(long id, InsertFloorDto floor)
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
