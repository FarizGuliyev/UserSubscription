using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels;

namespace cic_subscription_backend.Services.AddressServices.VillageServices
{
    public interface IVillageService
    {
        public Task<Village> InsertVillage(InsertVillageDto village);

        public Task<List<SelectVillageDto>> SelectVillages();
        
        public Task<List<SelectVillageDto>> SelectVillagesById(long Id);

        public Task<Village> UpdateVillage(long id, InsertVillageDto village);

        public Task<Village> RemoveVillage(long id);
    }
}