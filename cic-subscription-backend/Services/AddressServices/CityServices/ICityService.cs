using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.CityServices
{
    public interface ICityService
    {
        public Task<City> InsertCity(InsertCityDto city);

        public Task<List<SelectCityDto>> SelectCities();
        public Task<List<SelectCityDto>> SelectCitiesById(long Id);

        public Task<City> UpdateCity(long id, InsertCityDto city);

        public Task<City> RemoveCity(long id);
    }
}