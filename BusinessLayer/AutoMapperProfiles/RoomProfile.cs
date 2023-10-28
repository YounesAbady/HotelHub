using APIContract.RoomDTOs;
using AutoMapper;
using Models;

namespace BusinessLayer.AutoMapperProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomTinyDTO>().ReverseMap();
        }
    }
}
