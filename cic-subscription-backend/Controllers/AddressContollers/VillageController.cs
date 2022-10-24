using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;
using cic_subscription_backend.Services.AddressServices.VillageServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class VillageController : ControllerBase
    {
        private IVillageService service;
        private readonly DatabaseContext context;

        public VillageController(DatabaseContext context, IVillageService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Village>> PostVillage(InsertVillageDto village)
        {
            return Ok(await service.InsertVillage(village));
        }
       
        [HttpGet]
        public async Task<List<SelectVillageDto>> GetVillages()
        {
            List<SelectVillageDto> models = await service.SelectVillages();
            return models;
        }

        [HttpGet("{id}")]
        public async Task<List<SelectVillageDto>> GetVillagesById(long id)
        {
            List<SelectVillageDto> models = await service.SelectVillagesById(id);
            return models;
        }


        [HttpPut("{id}")]
        public async Task<Village> PutVillage(long id, InsertVillageDto village)
        {
            Village model = await service.UpdateVillage(id, village);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Village> DeleteVillage(long id)
        {
            Village village = await service.RemoveVillage(id);
            return village;
        }
    }
}