using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscription_backend.Services.AddressServices.FlatServices
{
    public interface IFlatService
    {
        public Task<Flat> InsertFlat(Flat flat);

        public Task<List<Flat>> SelectFlats();

        public Task<Flat> UpdateFlat(long id, Flat flat);

        public Task<Flat> RemoveFlat(long id);
    }
}