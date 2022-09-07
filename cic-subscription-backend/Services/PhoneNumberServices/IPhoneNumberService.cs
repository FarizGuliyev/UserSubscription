using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.PhoneNumberServices
{
    public interface IPhoneNumberService
    {
        public Task<PhoneNumber> InsertPhoneNumber(InsertPhoneNumberDto phoneNumberDto);

        public Task<List<PhoneNumber>> SelectPhoneNumber(long userId);
        public Task<PhoneNumber> UpdatePhoneNumber(long id, InsertPhoneNumberDto phoneNumberDto);
        public Task<PhoneNumber> RemovePhoneNumber(long id);
    }
}