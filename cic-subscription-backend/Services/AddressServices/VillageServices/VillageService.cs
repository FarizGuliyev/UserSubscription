using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.VillageServices
{
    public class VillageService:IVillageService
    {
            private DatabaseContext context;

            public VillageService(DatabaseContext databaseContext)
            {
                context = databaseContext;
            }

            public async Task<Village> InsertVillage(Village village)
            {
                Village newVillage = new Village();
                newVillage.Name = village.Name;
                newVillage.CityId = village.CityId;
                await context.Village.AddAsync(newVillage);
                await context.SaveChangesAsync();
                return newVillage;
            }

            public async Task<List<Village>> SelectVillages()
            {
                List<Village> villages = await context.Village.ToListAsync();
                return villages;
            }


            public async Task<Village> UpdateVillage(long id, Village village)
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
                    foundVillage.Name = village.Name;
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