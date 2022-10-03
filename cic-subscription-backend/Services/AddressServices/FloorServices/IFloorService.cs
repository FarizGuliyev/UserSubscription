using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.Models.LocationModels.Building;

namespace cic_subscription_backend.Services.AddressServices.FloorServices
{
    public interface IFloorService
    {
        public Task<Floor> InsertFloor(Floor floor);

        public Task<List<Floor>> SelectFloors();

        public Task<Floor> UpdateFloor(long id, Floor floor);

        public Task<Floor> RemoveFloor(long id);
    }
}