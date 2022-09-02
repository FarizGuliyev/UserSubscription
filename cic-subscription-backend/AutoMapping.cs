using AutoMapper;
using AutoMapper.EquivalencyExpression;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;

public class AutoMapping: Profile
{
    public AutoMapping()
    {
         CreateMap<InsertUserDto, User>();
         CreateMap<User,InsertUserDto>().EqualityComparison((odto, o) => odto.Id == o.Id);
    }
}
