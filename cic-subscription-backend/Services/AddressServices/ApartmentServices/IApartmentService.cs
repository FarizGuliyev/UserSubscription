using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscription_backend.Services.AddressServices.ApartmentServices
{
    public interface IApartmentService
    {
        public Task<Apartment> InsertApartment(InsertApartmentDto apartment);

        public Task<List<SelectApartmentDto>> SelectApartments();
        
        public Task<List<SelectApartmentDto>> SelectApartmentsByStreetId(long Id);

        public Task<List<SelectApartmentDto>> SelectApartmentsById(long Id);

        public Task<Apartment> UpdateApartment(long id, InsertApartmentDto apartment);

        public Task<Apartment> RemoveApartment(long id);
    }
}