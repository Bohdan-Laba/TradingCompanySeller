using AutoMapper;
using TradingCompany.DTO;

namespace DAL.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}