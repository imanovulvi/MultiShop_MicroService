using AutoMapper;
using MultiShop.Message.DTOs;
using ET=MultiShop.Message.DataAccess.Entityes;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<ET.Message, ResultMessageDTO>().ReverseMap();
            CreateMap<ET.Message, GetByIdMessageDTO>().ReverseMap();
            CreateMap<ET.Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<ET.Message, CreateMessageDTO>().ReverseMap();
        }
    }
}
