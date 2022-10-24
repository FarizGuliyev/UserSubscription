using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscription_backend.DTOs.MainDTOs;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

namespace cic_subscriptions_backend.Services.UserServices
{

    public interface IUserService
    {
        public Task<User> InsertUser(InsertUserDto userDto);
        public Task<List<SelectUserDto>> SelectUsersByRegionId(long id);
        public Task<List<SelectUserDto>> SelectUsersByCityId(long id);
        public Task<List<SelectUserDto>> SelectUsersByVillageId(long id);
        public Task<List<SelectUserDto>> SelectUsersByStreetId(long id);
        public Task<List<SelectUserDto>> SelectUsersByApartmentId(long id);
        public Task<List<SelectUserDto>> SelectUsersByFloorId(long id);
        public Task<List<SelectUserDto>> SelectUsersByFlatId(long id);
        public Task<List<SelectUserDto>> SelectUsers();
        public Task<User> UpdateUser(long id, InsertUserDto userDto);
        public Task<User> RemoveUser(long id);
    }
}