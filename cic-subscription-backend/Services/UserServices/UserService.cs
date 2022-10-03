using AutoMapper;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cic_subscriptions_backend.Services.UserServices

{

    public class UserService : IUserService
    {
        private DatabaseContext context;
        private IMapper mapping;

        public UserService(DatabaseContext databaseContext, IMapper autoMapping)
        {
            context = databaseContext;
            mapping = autoMapping;

        }


        public async Task<User> InsertUser(InsertUserDto userDto)
        {
            var user = mapping.Map<User>(userDto);
            await context.User.AddAsync(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task<List<User>> SelectUsers()
        {
            List<User> users = await context.User.ToListAsync();
            return users;
        }

        public async Task<User> SelectUserById(long id)
        {


            var foundUser = await context.User.FindAsync(id);
            if (foundUser == null)
            {
                throw new NotImplementedException();
            }
            return foundUser;
        }

        public async Task<User> UpdateUser(long id, InsertUserDto userDto)
        {

            if (id != userDto.Id)
            {
                throw new NotImplementedException();
            }
            var foundUser = await context.User.FindAsync(id);

            if (foundUser == null)
            {
                throw new NotImplementedException();
            }

            var updatePayment = mapping.Map<InsertUserDto, User>(userDto, foundUser);
            context.Entry(foundUser).CurrentValues.SetValues(userDto);
            await context.SaveChangesAsync();
            return foundUser;
        }


        public async Task<User> RemoveUser(long id)
        {
            User foundUser = await context.User.FindAsync(id);

            if (foundUser == null)
            {
                throw new NotImplementedException();
            }

            context.User.Remove(foundUser);
            await context.SaveChangesAsync();

            return foundUser;
        }


    }
}