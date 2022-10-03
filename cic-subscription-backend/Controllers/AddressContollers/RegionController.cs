using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models;
using cic_subscription_backend.Services.AddressServices.RegionServices;
using cic_subscriptions_backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers.AddressContollers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private IRegionService service;
        private readonly DatabaseContext context;

        public RegionController(DatabaseContext context, IRegionService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            return Ok(await service.InsertRegion(region));
        }

        [HttpGet]
        public async Task<List<Region>> GetRegions()
        {
            List<Region> models = await service.SelectRegions();
            return models;
        }



        [HttpPut("{id}")]
        public async Task<Region> PutRegion(long id, Region region)
        {
            Region model = await service.UpdateRegion(id, region);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<Region> DeleteRegion(long id)
        {
            Region region = await service.RemoveRegion(id);
            return region;
        }
    }
}