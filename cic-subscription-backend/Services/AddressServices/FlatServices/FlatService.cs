using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.House;
using cic_subscription_backend.Services.AddressServices.FlatServices;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices
{
    public class FlatService : IFlatService
    {
        private DatabaseContext context;

        public FlatService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Flat> InsertFlat(InsertFlatDto flat)
        {
            Flat newFlat = new Flat();
            newFlat.HouseName = flat.HouseName;
            newFlat.StreetId = flat.StreetId;
            newFlat.ApartmentId=flat.ApartmentId;
            newFlat.FloorId=flat.FloorId;
            await context.Flat.AddAsync(newFlat);
            await context.SaveChangesAsync();
            return newFlat;
        }

        public async Task<List<SelectFlatDto>> SelectFlats()
        {
            await using (context)
            {
                var flats=context.Flat
                .Include(x => x.street.city.region)
                .Include(x=>x.street.city)
                .Include(x=>x.street.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Select(
                  x=>
                  new SelectFlatDto()
                                {
                                      Id=x.Id,
                                      CityId=x.street.city.Id,
                                      VillageId=x.street.village.Id,
                                      StreetId = x.street.Id,
                                      FloorId=x.floor.Id,
                                      ApartmentId=x.apartment.Id,
                                      HouseName=x.HouseName,
                                      ApartmentName = x.apartment.ApartmentName ?? "",
                                      FloorName=x.floor.FloorName ?? "",
                                      StreetName = x.street.StreetName,
                                      VillageName = x.street.village.VillageName ?? "",
                                      CityName = x.street.city.CityName,
                                      RegionName = x.street.city.region.RegionName,
                                }).ToList();
                return flats;
            }
        }

        public async Task<List<SelectFlatDto>> SelectFlatsById(long Id)
        {
            await using (context)
            {
                var flats = (from floor in context.Floor
                              join flat in context.Flat on floor.Id equals flat.FloorId
                              where flat.FloorId == Id
                              select new SelectFlatDto()
                              {
                                  Id = flat.Id,
                                  HouseName = flat.HouseName,
                              }
                             ).ToList();

                return flats;
            }
        }

        public async Task<List<SelectFlatDto>> SelectFlatsByStreetId(long Id)
        {
            await using (context)
            {
                var flats = (from flat in context.Flat
                              where flat.StreetId == Id && flat.ApartmentId==null
                              select new SelectFlatDto()
                              {
                                  Id = flat.Id,
                                  HouseName = flat.HouseName,
                              }
                             ).ToList();

                return flats;
            }
        }


        public async Task<Flat> UpdateFlat(long id, InsertFlatDto flat)
        {
            if (id != flat.Id)
            {
                throw new NotImplementedException();
            }
            Flat foundFlat = await context.Flat.FindAsync(id);

            if (foundFlat == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundFlat.StreetId = flat.StreetId;
                foundFlat.ApartmentId=flat.ApartmentId;
                foundFlat.FloorId=flat.FloorId;
                foundFlat.HouseName = flat.HouseName;
                context.Entry(foundFlat).CurrentValues.SetValues(flat);
                await context.SaveChangesAsync();
            }

            return foundFlat;
        }

        public async Task<Flat> RemoveFlat(long id)
        {
            Flat foundFlat = await context.Flat.FindAsync(id);

            if (foundFlat == null)
            {
                throw new NotImplementedException();
            }

            context.Flat.Remove(foundFlat);
            await context.SaveChangesAsync();

            return foundFlat;
        }
    }
}