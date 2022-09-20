using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.PhoneNumberServices
{
    public interface IPaymentService
    {
        public  Task<Payment> InsertPayment(InsertPaymentDto paymentDto);
        public  Task<List<Payment>> SelectPaymentsById(long userId);
         public  Task<List<SelectPaymenttDto>> SelectPayments();
         public  Task<Payment> UpdatePayment(long id, InsertPaymentDto paymentDto);
         public  Task<Payment> RemovePayment(long id);
    }
}