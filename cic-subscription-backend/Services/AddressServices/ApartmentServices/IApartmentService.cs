using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscription_backend.Services.AddressServices.ApartmentServices
{
    public interface IApartmentService
    {
        public Task<Apartment> InsertApartment(Apartment apartment);

        public Task<List<Apartment>> SelectApartments();

        public Task<Apartment> UpdateApartment(long id, Apartment apartment);

        public Task<Apartment> RemoveApartment(long id);
    }
}