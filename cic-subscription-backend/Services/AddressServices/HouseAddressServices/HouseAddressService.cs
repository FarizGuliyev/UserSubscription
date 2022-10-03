using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.House;
using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace cic_subscription_backend.Services.AddressServices.HouseAddressServices
{
    public class HouseAddressService : IHouseAddressService
    {
        private DatabaseContext context;

        public HouseAddressService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<HouseAddress> InsertHouseAddress(HouseAddress houseAddress)
        {
            HouseAddress newHouseAddress = new HouseAddress();
            newHouseAddress.Address = houseAddress.Address;
            newHouseAddress.StreetId = houseAddress.StreetId;
            await context.HouseAddress.AddAsync(newHouseAddress);
            await context.SaveChangesAsync();
            return newHouseAddress;
        }

        public async Task<List<HouseAddress>> SelectHouseAddress()
        {
            List<HouseAddress> houseAddress = await context.HouseAddress.ToListAsync();
            return houseAddress;
        }


        public async Task<HouseAddress> UpdateHouseAddress(long id, HouseAddress houseAddress)
        {
            if (id != houseAddress.Id)
            {
                throw new NotImplementedException();
            }
            HouseAddress foundHouseAddress = await context.HouseAddress.FindAsync(id);

            if (foundHouseAddress == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                foundHouseAddress.StreetId = houseAddress.StreetId;
                foundHouseAddress.Address = houseAddress.Address;
                context.Entry(foundHouseAddress).CurrentValues.SetValues(houseAddress);
                await context.SaveChangesAsync();
            }

            return foundHouseAddress;
        }

        public async Task<HouseAddress> RemoveHouseAddress(long id)
        {
            HouseAddress foundHouseAddress = await context.HouseAddress.FindAsync(id);

            if (foundHouseAddress == null)
            {
                throw new NotImplementedException();
            }

            context.HouseAddress.Remove(foundHouseAddress);
            await context.SaveChangesAsync();

            return foundHouseAddress;
        }
    }
}