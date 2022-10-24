using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.VillageServices
{
    public class VillageService : IVillageService
    {
        private DatabaseContext context;

        public VillageService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Village> InsertVillage(InsertVillageDto village)
        {
            Village newVillage = new Village();
            newVillage.VillageName = village.VillageName;
            newVillage.CityId = village.CityId;
            await context.Village.AddAsync(newVillage);
            await context.SaveChangesAsync();
            return newVillage;
        }

        public async Task<List<SelectVillageDto>> SelectVillages()
        {
            await using (context)
            {
                var villages = (from r in context.Region
                                join c in context.City on r.Id equals c.RegionId
                                join v in context.Village on c.Id equals v.CityId
                                orderby c.Id
                                select new SelectVillageDto()
                                {
                                    Id = v.Id,
                                    CityId = c.Id,
                                    RegionId=r.Id,
                                    VillageName = v.VillageName,
                                    CityName = c.CityName,
                                    RegionName = r.RegionName,
                                }
                             ).ToList();

                return villages;
            }
        }

        public async Task<List<SelectVillageDto>> SelectVillagesById(long Id)
        {
            await using (context)
            {
                var villages = (from r in context.Region
                                join c in context.City on r.Id equals c.RegionId
                                join v in context.Village on c.Id equals v.CityId
                                where v.CityId == Id
                                select new SelectVillageDto()
                                {
                                    Id = v.Id,
                                    CityId = c.Id,
                                    VillageName = v.VillageName,
                                    CityName = c.CityName,
                                    RegionName = r.RegionName,
                                }
                             ).ToList();

                return villages;
            }
        }


        public async Task<Village> UpdateVillage(long id, InsertVillageDto village)
        {
            if (id != village.Id)
            {
                throw new NotImplementedException();
            }
            Village foundVillage = await context.Village.FindAsync(id);

            if (foundVillage == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundVillage.CityId = village.CityId;
                foundVillage.VillageName = village.VillageName;
                context.Entry(foundVillage).CurrentValues.SetValues(village);
                await context.SaveChangesAsync();
            }

            return foundVillage;
        }

        public async Task<Village> RemoveVillage(long id)
        {
            Village foundVillage = await context.Village.FindAsync(id);

            if (foundVillage == null)
            {
                throw new NotImplementedException();
            }

            context.Village.Remove(foundVillage);
            await context.SaveChangesAsync();

            return foundVillage;
        }
    }
}