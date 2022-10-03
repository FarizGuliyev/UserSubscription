using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Street> InsertStreet(Street street)
        {
            Street newStreet = new Street();
            newStreet.Name = street.Name;
            newStreet.VillageId = street.VillageId;
            await context.Street.AddAsync(newStreet);
            await context.SaveChangesAsync();
            return newStreet;
        }

        public async Task<List<Street>> SelectStreets()
        {
            List<Street> street = await context.Street.ToListAsync();
            return street;
        }


        public async Task<Street> UpdateStreet(long id, Street street)
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
                foundStreet.Name = street.Name;
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