using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.StreetServices
{
    public interface IStreetService
    {
        public Task<Street> InsertStreet(Street street);

        public Task<List<Street>> SelectStreets();

        public Task<Street> UpdateStreet(long id, Street street);

        public Task<Street> RemoveStreet(long id);
    }
}