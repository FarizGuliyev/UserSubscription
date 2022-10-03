using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.FlatServices
{
    public class FlatService : IFlatService
    {
        private DatabaseContext context;

        public FlatService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Flat> InsertFlat(Flat flat)
        {
            Flat newFlat = new Flat();
            newFlat.Address = flat.Address;
            newFlat.FloorId = flat.FloorId;
            await context.Flat.AddAsync(newFlat);
            await context.SaveChangesAsync();
            return newFlat;
        }

        public async Task<List<Flat>> SelectFlats()
        {
            List<Flat> flats = await context.Flat.ToListAsync();
            return flats;
        }


        public async Task<Flat> UpdateFlat(long id, Flat flat)
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
                foundFlat.FloorId = flat.FloorId;
                foundFlat.Address = flat.Address;
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