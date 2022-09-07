using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.PhoneNumberServices
{
    public class PhoneNumberService : IPhoneNumberService
    {

        private DatabaseContext context;
        private IMapper mapping;
        public PhoneNumberService(DatabaseContext databaseContext, IMapper autoMapping)
        {
            context = databaseContext;
            mapping = autoMapping;
        }
        public async Task<PhoneNumber> InsertPhoneNumber(InsertPhoneNumberDto phoneNumberDto)
        {
            var phoneNumber = mapping.Map<PhoneNumber>(phoneNumberDto);
            await context.PhoneNumber.AddAsync(phoneNumber);
            await context.SaveChangesAsync();
            return phoneNumber;
        }

        public async Task<List<PhoneNumber>> SelectPhoneNumber(long userId)
        {
            await using (context)
            {
                var phoneNumber = (from u in context.User
                                   join pn in context.PhoneNumber on u.Id equals pn.UserId
                                   where pn.UserId == userId
                                   select new PhoneNumber()
                                   {
                                       Id = pn.Id,
                                       UserId = pn.UserId,
                                       Number = pn.Number
                                   }
                             ).ToList();
                return phoneNumber;
            }

        }

        public async Task<PhoneNumber> UpdatePhoneNumber(long id, InsertPhoneNumberDto phoneNumberDto)
        {
            if (id != phoneNumberDto.Id)
            {
                throw new NotImplementedException();
            }
            var foundPhoneNumber = await context.PhoneNumber.FindAsync(id);

            if (foundPhoneNumber == null)
            {
                throw new NotImplementedException();
            }

            var updatePhoneNumber = mapping
            .Map<InsertPhoneNumberDto, PhoneNumber>(phoneNumberDto, foundPhoneNumber);

            context.Entry(foundPhoneNumber).CurrentValues.SetValues(phoneNumberDto);
            await context.SaveChangesAsync();
            return foundPhoneNumber;
        }
        public async Task<PhoneNumber> RemovePhoneNumber(long id)
        {
            PhoneNumber foundPhoneNumber = await context.PhoneNumber.FindAsync(id);

            if (foundPhoneNumber == null)
            {
                throw new NotImplementedException();
            }

            context.PhoneNumber.Remove(foundPhoneNumber);
            await context.SaveChangesAsync();

            return foundPhoneNumber;
        }


    }
}
