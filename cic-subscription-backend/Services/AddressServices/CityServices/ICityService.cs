using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.CityServices
{
    public interface ICityService
    {
        public Task<City> InsertCity(City city);

        public Task<List<City>> SelectCities();

        public Task<City> UpdateCity(long id, City city);

        public Task<City> RemoveCity(long id);
    }
}