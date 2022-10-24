using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.House;

namespace cic_subscription_backend.Services.AddressServices.FlatServices
{
    public interface IFlatService
    {
        public Task<Flat> InsertFlat(InsertFlatDto flat);
        public Task<List<SelectFlatDto>> SelectFlatsByStreetId(long Id);
        public Task<List<SelectFlatDto>> SelectFlats();

        public Task<List<SelectFlatDto>> SelectFlatsById(long Id);

        public Task<Flat> UpdateFlat(long id, InsertFlatDto flat);

        public Task<Flat> RemoveFlat(long id);
    }
}