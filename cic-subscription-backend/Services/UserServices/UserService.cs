using AutoMapper;
using cic_subscription_backend.DTOs;
using cic_subscription_backend.DTOs.MainDTOs;
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

public async Task<List<SelectUserDto>> SelectUsersByRegionId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.region.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByCityId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.city.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByVillageId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.village.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByStreetId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.street.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByApartmentId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.apartment.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByFloorId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.floor.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

        public async Task<List<SelectUserDto>> SelectUsersByFlatId(long id)
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Where(x => x.flat.Id==id)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
        }

       
        public async Task<List<SelectUserDto>> SelectUsers()
        {
           await using (context)
            {
                var users=context.User
                .Include(x => x.region)
                .Include(x=>x.city)
                .Include(x=>x.village)
                .Include(x=>x.street)
                .Include(x=>x.apartment)
                .Include(x=>x.floor)
                .Include(x=>x.flat)
                .Select(
                  x=>
                  new SelectUserDto()
                                {
                                    Id=x.Id,
                                    Name = x.Name,
                                    Surname = x.Surname,
                                    FatherName = x.FatherName,
                                    SubscriptionDate = x.SubscriptionDate,
                                    Debt = x.Debt,
                                    SubscriptionTypeId=x.SubscriptionTypeId,
                                    RegionId=x.RegionId,
                                    CityId=x.CityId,
                                    VillageId=x.VillageId,
                                    StreetId=x.StreetId,
                                    ApartmentId=x.ApartmentId,
                                    FloorId=x.FloorId,
                                    FlatId= x.FlatId,
                                    RegionName=x.region.RegionName ?? "",
                                    CityName=x.city.CityName ?? "",
                                    VillageName=x.village.VillageName ?? "",
                                    StreetName=x.street.StreetName ?? "",
                                    HouseName=x.flat.HouseName ?? "",
                                    ApartmentName=x.apartment.ApartmentName ?? "", 
                                    FloorName=x.floor.FloorName ?? ""
                                }).ToList();
                return users;
            }
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