using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.StreetServices
{
    public interface IStreetService
    {
        public Task<Street> InsertStreet(InsertStreetDto street);

         public Task<List<SelectStreetDto>> SelectStreetsByCityId(long Id);
        public Task<List<SelectStreetDto>> SelectStreets();
        public Task<List<SelectStreetDto>> SelectStreetsById(long Id);

        public Task<Street> UpdateStreet(long id, InsertStreetDto street);

        public Task<Street> RemoveStreet(long id);
    }
}