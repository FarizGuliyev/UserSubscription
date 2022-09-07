using AutoMapper;
using AutoMapper.EquivalencyExpression;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<InsertUserDto, User>();
        CreateMap<User, InsertUserDto>().EqualityComparison((user, dto) => user.Id == dto.Id);
        CreateMap<InsertPaymentDto,Payment>();
        CreateMap<Payment, InsertPaymentDto>().EqualityComparison((payment, dto) => payment.Id == dto.Id);
        CreateMap<InsertPhoneNumberDto,PhoneNumber>();
        CreateMap<PhoneNumber, InsertPhoneNumberDto>().EqualityComparison((phoneNumber, dto) => phoneNumber.Id == dto.Id);
        CreateMap<InsertSubscriptionTypeDto,SubscriptionType>();
        CreateMap<SubscriptionType, InsertSubscriptionTypeDto>().EqualityComparison((subType, dto) => subType.Id == dto.Id);
    }
}
