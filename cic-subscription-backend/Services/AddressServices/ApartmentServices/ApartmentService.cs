using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.ApartmentServices
{
    public class ApartmentService : IApartmentService
    {
        private DatabaseContext context;

        public ApartmentService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Apartment> InsertApartment(InsertApartmentDto apartment)
        {
            Apartment newApartment = new Apartment();
            newApartment.ApartmentName = apartment.ApartmentName;
            newApartment.StreetId = apartment.StreetId;
            await context.Apartment.AddAsync(newApartment);
            await context.SaveChangesAsync();
            return newApartment;
        }

 public async Task<List<SelectApartmentDto>> SelectApartmentsByStreetId(long Id)
        {
            await using (context)
            {
                var apartments = (from r in context.Region
                               join c in context.City on r.Id equals c.RegionId
                               join s in context.Street on c.Id equals s.CityId
                               join a in context.Apartment on s.Id equals a.StreetId
                               where a.StreetId == Id
                               select new SelectApartmentDto()
                               {
                                   Id = a.Id,
                                   ApartmentName=a.ApartmentName,
                                   StreetId=s.Id,
                                   StreetName = s.StreetName,
                                   CityName = c.CityName,
                                   RegionName = r.RegionName,

                               }
                             ).ToList();

                return apartments;
            }
        }

        public async Task<List<SelectApartmentDto>> SelectApartments()
        {
            await using (context)
            {

                var apartments=context.Apartment
                .Include(x => x.street.city.region)
                .Include(x=>x.street.city)
                .Include(x=>x.street.village)
                .Include(x=>x.street)
                .Select(
                  x=>
                  new SelectApartmentDto()
                                {
                                      Id=x.Id,
                                      StreetId = x.street.Id,
                                      ApartmentName = x.ApartmentName,
                                      StreetName = x.street.StreetName,
                                      VillageName = x.street.village.VillageName ?? "",
                                      CityName = x.street.city.CityName,
                                      RegionName = x.street.city.region.RegionName,
                                }).ToList();
                return apartments;
            }
        }

        public async Task<List<SelectApartmentDto>> SelectApartmentsById(long Id)
        {
            await using (context)
            {
                var apartments = (from r in context.Region
                                  join c in context.City on r.Id equals c.RegionId
                                  join v in context.Village on c.Id equals v.CityId
                                  join s in context.Street on v.Id equals s.VillageId
                                  join a in context.Apartment on s.Id equals a.StreetId
                                  where a.StreetId == Id
                                  select new SelectApartmentDto()
                                  {
                                      Id = a.Id,
                                      StreetId = s.Id,
                                      ApartmentName = a.ApartmentName,
                                      StreetName = s.StreetName,
                                      VillageName = v.VillageName,
                                      CityName = c.CityName,
                                      RegionName = r.RegionName,

                                  }
                             ).ToList();

                return apartments;
            }
        }



        public async Task<Apartment> UpdateApartment(long id, InsertApartmentDto apartment)
        {
            if (id != apartment.Id)
            {
                throw new NotImplementedException();
            }
            var foundApartment = await context.Apartment.FindAsync(id);

            if (foundApartment == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundApartment.StreetId = apartment.StreetId;
                foundApartment.ApartmentName = apartment.ApartmentName;
                context.Entry(foundApartment).CurrentValues.SetValues(apartment);
                await context.SaveChangesAsync();
            }

            return foundApartment;
        }

        public async Task<Apartment> RemoveApartment(long id)
        {
            Apartment foundApartment = await context.Apartment.FindAsync(id);

            if (foundApartment == null)
            {
                throw new NotImplementedException();
            }

            context.Apartment.Remove(foundApartment);
            await context.SaveChangesAsync();

            return foundApartment;
        }

    }
}