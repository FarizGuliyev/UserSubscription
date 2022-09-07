using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Models;

namespace cic_subscription_backend.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {

        private DatabaseContext context;
        private IMapper mapping;
        public PaymentService(DatabaseContext databaseContext, IMapper autoMapping)
        {
            context = databaseContext;
            mapping = autoMapping;
        }

        public async Task<Payment> InsertPayment(InsertPaymentDto paymentDto)
        {
            var payment = mapping.Map<Payment>(paymentDto);
            await context.Payment.AddAsync(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task<List<Payment>> SelectPayments(long userId)
        {
            await using (context)
            {
                var payments = (from u in context.User
                             join p in context.Payment on u.Id equals p.UserId
                             where p.UserId == userId

                             select new Payment()
                             {
                                Id=p.Id,
                                UserId=p.UserId,
                                Amount=p.Amount,
                                Type=p.Type,
                                Date=p.Date,
                                Note=p.Note
                             }
                             ).ToList();

                             return payments;
            }
        }

        public async Task<Payment> UpdatePayment(long id, InsertPaymentDto paymentDto)
        {
            if (id != paymentDto.Id)
            {
                throw new NotImplementedException();
            }
            var foundPayment = await context.Payment.FindAsync(id);

            if (foundPayment == null)
            {
                throw new NotImplementedException();
            }

            var updatePayment = mapping.Map<InsertPaymentDto, Payment>(paymentDto, foundPayment);
            context.Entry(foundPayment).CurrentValues.SetValues(paymentDto);
            await context.SaveChangesAsync();
            return foundPayment;


        }

        public async Task<Payment> RemovePayment(long id)
        {
            Payment foundPayment = await context.Payment.FindAsync(id);

            if (foundPayment == null)
            {
                throw new NotImplementedException();
            }

            context.Payment.Remove(foundPayment);
            await context.SaveChangesAsync();

            return foundPayment;
        }


    }
}
