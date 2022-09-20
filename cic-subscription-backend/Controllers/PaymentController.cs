using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
using cic_subscription_backend.Services.PaymentServices;
using cic_subscription_backend.Services.PhoneNumberServices;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cic_subscription_backend.Controllers
{

    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private IPaymentService service;
        private readonly DatabaseContext context;

        public PaymentController(DatabaseContext context, IPaymentService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(InsertPaymentDto paymentDto)
        {
            return Ok(await service.InsertPayment(paymentDto));
        }


        [HttpGet("{userId}")]
        public async Task<List<Payment>> GetPaymentsById(long userId)
        {
            List<Payment> models = await service.SelectPaymentsById(userId);
            return models;
        }


        [HttpGet]
        public async Task<List<SelectPaymenttDto>> GetPayments(){
            List<SelectPaymenttDto> models = await service.SelectPayments();
            return models;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Payment>> PutPayment(long id, InsertPaymentDto paymentDto)
        {
            Payment payment = await service.UpdatePayment(id, paymentDto);
            return payment;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(long id)
        {
            Payment payment = await service.RemovePayment(id);
            return payment;
        }


    }
}