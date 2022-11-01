
using AutoMapper;
using TradingCompany.DTO;

namespace DAL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}