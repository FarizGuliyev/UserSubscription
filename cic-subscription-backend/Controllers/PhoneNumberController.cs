using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cic_subscription_backend.DTOs;
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
    public class PhoneNumberController : ControllerBase
    {
        private IPhoneNumberService service;
        private readonly DatabaseContext context;

        public PhoneNumberController(DatabaseContext context, IPhoneNumberService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PhoneNumber>> PostPhoneNumber(InsertPhoneNumberDto phoneNumberDto)
        {
            return Ok(await service.InsertPhoneNumber(phoneNumberDto));
        }

        [HttpGet]
        public async Task<List<SelectPhoneNumberDto>> GetPhoneNumber()
        {
            List<SelectPhoneNumberDto> models = await service.SelectPhoneNumber();
            return models;
        }

        [HttpGet("{userId}")]
        public async Task<List<PhoneNumber>> GetPhoneNumberById(long userId)
        {
            List<PhoneNumber> models = await service.SelectPhoneNumberById(userId);
            return models;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PhoneNumber>> PutPhoneNumber(long id, InsertPhoneNumberDto phoneNumberDtoDto)
        {
            PhoneNumber phoneNumber = await service.UpdatePhoneNumber(id, phoneNumberDtoDto);
            return phoneNumber;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneNumber>> DeletePhoneNumber(long id)
        {
            PhoneNumber phoneNumber = await service.RemovePhoneNumber(id);
            return phoneNumber;
        }
    }
}