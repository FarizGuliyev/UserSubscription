using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

namespace cic_subscriptions_backend.Services.UserServices
{

    public interface IUserService
    {
        public Task<User> InsertUser(InsertUserDto userDto);
        public Task<List<User>> SelectUsers();
        public Task<User> SelectUserById(long id);
        public Task<User> UpdateUser(long id, InsertUserDto userDto);
        public Task<User> RemoveUser(long id);
    }
}