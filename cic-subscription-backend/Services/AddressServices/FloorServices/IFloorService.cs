using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs.AddressDTOs;
using cic_subscription_backend.DTOs.AddressDTOs.InsertDTOs;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscription_backend.Services.AddressServices.FloorServices
{
    public interface IFloorService
    {
        public Task<Floor> InsertFloor(InsertFloorDto floor);

        public Task<List<SelectFloorDto>> SelectFloors();

        public Task<List<SelectFloorDto>> SelectFloorsById(long Id);

        public Task<Floor> UpdateFloor(long id, InsertFloorDto floor);

        public Task<Floor> RemoveFloor(long id);
         }
}