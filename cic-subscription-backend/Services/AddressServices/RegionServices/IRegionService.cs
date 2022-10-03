using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models;

namespace cic_subscription_backend.Services.AddressServices.RegionServices
{
    public interface IRegionService
    {
        public Task<Region> InsertRegion(Region region);

        public Task<List<Region>> SelectRegions();

        public Task<Region> UpdateRegion(long id, Region region);

        public Task<Region> RemoveRegion(long id);
    }
}