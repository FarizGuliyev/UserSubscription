using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.StreetServices
{
    public class StreetService : IStreetService
    {
        private DatabaseContext context;

        public StreetService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Street> InsertStreet(InsertStreetDto street)
        {
            Street newStreet = new Street();
            newStreet.StreetName = street.StreetName;
            newStreet.CityId=street.CityId;
            newStreet.VillageId = street.VillageId;
            await context.Street.AddAsync(newStreet);
            await context.SaveChangesAsync();
            return newStreet;
        }

        public async Task<List<SelectStreetDto>> SelectStreets()
        {
            await using (context)
            {

                var streets=context.Street
                .Include(x => x.city.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Select(
                  x=>
                  new SelectStreetDto()
                                {
                                    Id=x.Id,
                                    VillageId = x.village.Id,
                                    CityId = x.city.Id,
                                    StreetName = x.StreetName,
                                    VillageName = x.village.VillageName ?? "",
                                    CityName = x.city.CityName,
                                    RegionName=x.city.region.RegionName,
                                }).ToList();
                return streets;
            }
        }

        public async Task<List<SelectStreetDto>> SelectStreetsByCityId(long Id)
        {
            await using (context)
            {
                var streets = (from r in context.Region
                               join c in context.City on r.Id equals c.RegionId
                               join s in context.Street on c.Id equals s.CityId
                               where s.CityId == Id && s.VillageId==null
                               select new SelectStreetDto()
                               {
                                   Id = s.Id,
                                   CityId=c.Id,
                                   StreetName = s.StreetName,
                                   CityName = c.CityName,
                                   RegionName = r.RegionName,

                               }
                             ).ToList();

                return streets;
            }
        }

        public async Task<List<SelectStreetDto>> SelectStreetsById(long Id)
        {
            await using (context)
            {
                var streets = (from r in context.Region
                               join c in context.City on r.Id equals c.RegionId
                               join v in context.Village on c.Id equals v.CityId
                               join s in context.Street on v.Id equals s.VillageId
                               where s.VillageId == Id
                               select new SelectStreetDto()
                               {
                                   Id = s.Id,
                                   VillageId = v.Id,
                                   CityId=c.Id,
                                   StreetName = s.StreetName,
                                   VillageName = v.VillageName,
                                   CityName = c.CityName,
                                   RegionName = r.RegionName,

                               }
                             ).ToList();

                return streets;
            }
        }


        public async Task<Street> UpdateStreet(long id, InsertStreetDto street)
        {
            if (id != street.Id)
            {
                throw new NotImplementedException();
            }
            Street foundStreet = await context.Street.FindAsync(id);

            if (foundStreet == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundStreet.VillageId = street.VillageId;
                foundStreet.CityId=street.CityId;
                foundStreet.StreetName = street.StreetName;
                context.Entry(foundStreet).CurrentValues.SetValues(street);
                await context.SaveChangesAsync();
            }

            return foundStreet;
        }

        public async Task<Street> RemoveStreet(long id)
        {
            Street foundStreet = await context.Street.FindAsync(id);

            if (foundStreet == null)
            {
                throw new NotImplementedException();
            }

            context.Street.Remove(foundStreet);
            await context.SaveChangesAsync();

            return foundStreet;
        }
    }
}