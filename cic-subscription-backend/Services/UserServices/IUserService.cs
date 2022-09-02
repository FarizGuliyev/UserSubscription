using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

namespace cic_subscriptions_backend.Services.UserServices
{

    public interface IUserService
    {
        public User InsertUser(InsertUserDto userDto);
        public List<User> SelectUser();
        public User UpdateUser(long id,InsertUserDto userDto); 
        public User DeleteUser(long id);
    }
}