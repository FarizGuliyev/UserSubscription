using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using cic_subscription_backend.DTOs;
using cic_subscription_backend.Services.PhoneNumberServices;
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


        public async Task<List<SelectPaymentByUserDto>> SelectPaymentsByUser()
        {
            await using (context)
            {
                var payments = (from u in context.User  
                                join p in context.Payment on u.Id equals p.UserId
                                orderby p.UserId
                                select new SelectPaymentByUserDto()
                                {
                                    Id = p.Id,
                                    UserId = p.UserId,
                                    UserName = u.Name,
                                    Surname=u.Surname,
                                    Amount = p.Amount,
                                    Type = p.Type,
                                    PayDate = p.PayDate,
                                    Note = p.Note
                                }
                             ).ToList();

                return payments;
            }
        }


        public async Task<List<SelectPaymentByUserDto>> SelectPaymentsById(long userId)
        {
            await using (context)
            {
                var payments = (from u in context.User
                                join p in context.Payment on u.Id equals p.UserId
                                where p.UserId == userId
                                select new SelectPaymentByUserDto()
                                {
                                    Id = p.Id,
                                    UserId = p.UserId,
                                    UserName = u.Name,
                                    Surname=u.Surname,
                                    Amount = p.Amount,
                                    Type = p.Type,
                                    PayDate = p.PayDate,
                                    Note = p.Note
                                }
                             ).ToList();

                return payments;
            }
        }

        public async Task<List<SelectPaymenttDto>> SelectPayments()
        {
            await using (context)
            {
                var payments=context.Payment
                .Include(x => x.user)
                .Include(x=>x.user.subs) 
                .Select(
                  x=>
                  new SelectPaymenttDto()
                                {
                                    UserName = x.user.Name,
                                    ProductAmount = x.user.subs.Price ,
                                    PaymentAmount = x.Amount,
                                    PaymentDate = x.PayDate.ToString("yyyy:MM:dd"),
                                    Debt = x.user.Debt,
                                }).ToList();
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
