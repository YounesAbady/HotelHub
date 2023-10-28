using APIContract.RoomPictureDTO;
using AutoMapper;
using Models;

namespace BusinessLayer.AutoMapperProfiles
{
    public class RoomPictureProfile : Profile
    {
        public RoomPictureProfile()
        {
            CreateMap<RoomPicture, RoomPictureTinyDTO>().ReverseMap();
        }
    }
}
