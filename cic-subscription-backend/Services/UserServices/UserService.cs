using AutoMapper;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

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


        public User InsertUser(InsertUserDto userDto)
        {
            var user = mapping.Map<User>(userDto);
            context.userContext.Add(user);
            context.SaveChanges();
            return user;

        }

        public List<User> SelectUser()
        {
            List<User> userList = context.userContext.ToList();
            return userList;
        }

        public User UpdateUser(long id, InsertUserDto userDto)
        {
            if (id != userDto.Id)
            {
                throw new NotImplementedException();
            }
            var foundUser = context.userContext.Find(id);

            if (foundUser == null)
            {
                throw new NotImplementedException();
            }

            var updateUser = mapping.Map<InsertUserDto, User>(userDto, foundUser);
            context.Entry(foundUser).CurrentValues.SetValues(userDto);
            context.SaveChanges();
            return foundUser;
        }
        public User DeleteUser(long id)
        {
            User foundUser = context.userContext.Find(id);

            if (foundUser == null)
            {
                throw new NotImplementedException();
            }

            context.userContext.Remove(foundUser);
            context.SaveChangesAsync();

            return foundUser;
        }


    }
}