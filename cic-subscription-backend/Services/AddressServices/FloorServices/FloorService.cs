using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
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

        public async Task<Floor> InsertFloor(InsertFloorDto floor)
        {
            Floor newFloor = new Floor();
            newFloor.FloorName = floor.FloorName;
            newFloor.ApartmentId = floor.ApartmentId;
            await context.Floor.AddAsync(newFloor);
            await context.SaveChangesAsync();
            return newFloor;
        }

        public async Task<List<SelectFloorDto>> SelectFloors()
        {
            await using (context)
            {

                var apartments=context.Floor
                .Include(x => x.apartment.street.city.region)
                .Include(x=>x.apartment.street.city)
                .Include(x=>x.apartment.street.village)
                .Include(x=>x.apartment.street)
                .Include(x=>x.apartment)
                .Select(
                  x=>
                  new SelectFloorDto()
                                {
                                      Id=x.Id,
                                      ApartmentId = x.apartment.Id,
                                      StreetId=x.apartment.street.Id,
                                      FloorName=x.FloorName,
                                      ApartmentName = x.apartment.ApartmentName,
                                      StreetName = x.apartment.street.StreetName,
                                      VillageName = x.apartment.street.village.VillageName ?? "",
                                      CityName = x.apartment.street.city.CityName,
                                      RegionName = x.apartment.street.city.region.RegionName,
                                }).ToList();
                return apartments;
            }
        }

        public async Task<List<SelectFloorDto>> SelectFloorsById(long Id)
        {
            await using (context)
            {
                var floors = (from a in context.Apartment
                              join floor in context.Floor on a.Id equals floor.ApartmentId
                              where floor.ApartmentId == Id
                              select new SelectFloorDto()
                              {
                                  Id = floor.Id,
                                  ApartmentId = a.Id,
                                  FloorName = floor.FloorName,
                                  ApartmentName = a.ApartmentName,
                              }
                             ).ToList();

                return floors;
            }
        }

        public async Task<Floor> UpdateFloor(long id, InsertFloorDto floor)
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
                foundFloor.FloorName = floor.FloorName;
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