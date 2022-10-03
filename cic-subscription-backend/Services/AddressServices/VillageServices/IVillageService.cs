using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.VillageServices
{
    public interface IVillageService
    {
        public Task<Village> InsertVillage(Village village);

        public Task<List<Village>> SelectVillages();

        public Task<Village> UpdateVillage(long id, Village village);

        public Task<Village> RemoveVillage(long id);
    }
}