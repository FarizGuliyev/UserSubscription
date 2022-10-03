using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.FloorServices
{
    public class FloorService : IFloorService
    {
        private DatabaseContext context;

        public FloorService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Floor> InsertFloor(Floor floor)
        {
            Floor newFloor = new Floor();
            newFloor.Name = floor.Name;
            newFloor.ApartmentId = floor.ApartmentId;
            await context.Floor.AddAsync(newFloor);
            await context.SaveChangesAsync();
            return newFloor;
        }

        public async Task<List<Floor>> SelectFloors()
        {
            List<Floor> floors = await context.Floor.ToListAsync();
            return floors;
        }


        public async Task<Floor> UpdateFloor(long id, Floor floor)
        {
            if (id != floor.Id)
            {
                throw new NotImplementedException();
            }
            Floor foundFloor = await context.Floor.FindAsync(id);

            if (foundFloor == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundFloor.ApartmentId = floor.ApartmentId;
                foundFloor.Name = floor.Name;
                context.Entry(foundFloor).CurrentValues.SetValues(floor);
                await context.SaveChangesAsync();
            }

            return foundFloor;
        }

        public async Task<Floor> RemoveFloor(long id)
        {
            Floor foundFloor = await context.Floor.FindAsync(id);

            if (foundFloor == null)
            {
                throw new NotImplementedException();
            }

            context.Floor.Remove(foundFloor);
            await context.SaveChangesAsync();

            return foundFloor;
        }
    }
}