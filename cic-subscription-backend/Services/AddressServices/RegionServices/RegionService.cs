using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.RegionServices
{
    public class RegionService : IRegionService
    {
        private DatabaseContext context;

        public RegionService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Region> InsertRegion(Region region)
        {
            Region newRegion = new Region();
            newRegion.Name = region.Name;

            await context.Region.AddAsync(newRegion);
            await context.SaveChangesAsync();
            return newRegion;
        }

        public async Task<List<Region>> SelectRegions()
        {
            List<Region> regions = await context.Region.ToListAsync();
            return regions;
        }


        public async Task<Region> UpdateRegion(long id, Region region)
        {
            if (id != region.Id)
            {
                throw new NotImplementedException();
            }
            Region foundRegion = await context.Region.FindAsync(id);

            if (foundRegion == null)
            {
                throw new NotImplementedException();
            }
            else
            {

                foundRegion.Name = region.Name;
                context.Entry(foundRegion).CurrentValues.SetValues(region);
                await context.SaveChangesAsync();
            }

            return foundRegion;
        }

        public async Task<Region> RemoveRegion(long id)
        {
            Region foundRegion = await context.Region.FindAsync(id);

            if (foundRegion == null)
            {
                throw new NotImplementedException();
            }

            context.Region.Remove(foundRegion);
            await context.SaveChangesAsync();

            return foundRegion;
        }
    }
}