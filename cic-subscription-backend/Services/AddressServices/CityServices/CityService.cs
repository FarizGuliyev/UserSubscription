using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.CityServices
{
    public class CityService : ICityService
    {
        private DatabaseContext context;

        public CityService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<City> InsertCity(City city)
        {
            City newCity = new City();
            newCity.Name = city.Name;
            newCity.RegionId = city.RegionId;
            await context.City.AddAsync(newCity);
            await context.SaveChangesAsync();
            return newCity;
        }

        public async Task<List<City>> SelectCities()
        {
            List<City> city = await context.City.ToListAsync();
            return city;
        }


        public async Task<City> UpdateCity(long id, City city)
        {
            if (id != city.Id)
            {
                throw new NotImplementedException();
            }
            City foundCity = await context.City.FindAsync(id);

            if (foundCity == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundCity.RegionId = city.RegionId;
                foundCity.Name = city.Name;
                context.Entry(foundCity).CurrentValues.SetValues(city);
                await context.SaveChangesAsync();
            }

            return foundCity;
        }

        public async Task<City> RemoveCity(long id)
        {
            City foundCity = await context.City.FindAsync(id);

            if (foundCity == null)
            {
                throw new NotImplementedException();
            }

            context.City.Remove(foundCity);
            await context.SaveChangesAsync();

            return foundCity;
        }
    }
}