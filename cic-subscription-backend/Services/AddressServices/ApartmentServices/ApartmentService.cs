using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Apartment> InsertApartment(Apartment apartment)
        {
            Apartment newApartment = new Apartment();
            newApartment.Name = apartment.Name;
            newApartment.StreetId = apartment.StreetId;
            await context.Apartment.AddAsync(newApartment);
            await context.SaveChangesAsync();
            return newApartment;
        }

        public async Task<List<Apartment>> SelectApartments()
        {
            List<Apartment> apartment = await context.Apartment.ToListAsync();
            return apartment;
        }


        public async Task<Apartment> UpdateApartment(long id, Apartment apartment)
        {
            if (id != apartment.Id)
            {
                throw new NotImplementedException();
            }
            Apartment foundApartment = await context.Apartment.FindAsync(id);

            if (foundApartment == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundApartment.StreetId = apartment.StreetId;
                foundApartment.Name = apartment.Name;
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