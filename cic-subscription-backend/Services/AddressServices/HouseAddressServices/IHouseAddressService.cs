using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.House;

namespace cic_subscription_backend.Services.AddressServices.HouseAddressServices
{
    public interface IHouseAddressService
    {
        public Task<HouseAddress> InsertHouseAddress(HouseAddress houseAddress);

        public Task<List<HouseAddress>> SelectHouseAddress();

        public Task<HouseAddress> UpdateHouseAddress(long id, HouseAddress houseAddress);

        public Task<HouseAddress> RemoveHouseAddress(long id);
    }
}