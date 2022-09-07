using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.PaymentServices
{
    public interface IPaymentService
    {
        public Task<Payment> InsertPayment(InsertPaymentDto userDto);

        public Task<List<Payment>> SelectPayments(long userId);
        public Task<Payment> UpdatePayment(long id, InsertPaymentDto userDto);
        public Task<Payment> RemovePayment(long id);
    }
}