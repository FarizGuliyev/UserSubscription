using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
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

        public async Task<City> InsertCity(InsertCityDto city)
        {
            City newCity = new City();
            newCity.CityName = city.CityName;
            newCity.RegionId = city.RegionId;
            await context.City.AddAsync(newCity);
            await context.SaveChangesAsync();
            return newCity;
        }

        public async Task<List<SelectCityDto>> SelectCities()
        {
            await using (context)
            {
                var cities = (from r in context.Region
                              join c in context.City on r.Id equals c.RegionId
                              orderby c.RegionId
                              select new SelectCityDto()
                              {
                                  Id = c.Id,
                                  RegionId = c.RegionId,
                                  CityName = c.CityName,
                                  RegionName = r.RegionName,
                              }
                             ).ToList();

                return cities;
            }
        }

        public async Task<List<SelectCityDto>> SelectCitiesById(long Id)
        {
            await using (context)
            {
                var cities = (from r in context.Region
                              join c in context.City on r.Id equals c.RegionId
                              where c.RegionId == Id
                              select new SelectCityDto()
                              {
                                  Id = c.Id,
                                  RegionId = c.RegionId,
                                  CityName = c.CityName,
                                  RegionName = r.RegionName,
                              }
                             ).ToList();

                return cities;
            }
        }


        public async Task<City> UpdateCity(long id, InsertCityDto city)
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
                foundCity.CityName = city.CityName;
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