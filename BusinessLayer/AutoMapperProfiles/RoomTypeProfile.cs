using APIContract.RoomTypeDTOs;
using AutoMapper;
using Models;

namespace BusinessLayer.AutoMapperProfiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomsType, RoomTypeTinyDTO>().ReverseMap();
        }
    }
}
