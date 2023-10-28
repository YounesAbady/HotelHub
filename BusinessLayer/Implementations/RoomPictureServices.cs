using APIContract.RoomPictureDTO;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class RoomPictureServices : IRoomPictureServices
    {
        private readonly IRoomPicturesRepository _roomPictureRepository;
        private readonly IMapper _mapper;

        public RoomPictureServices(IRoomPicturesRepository roomPicturesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _roomPictureRepository = roomPicturesRepository;
        }

        public async Task<List<RoomPictureTinyDTO>> GetAllRoomPictures()
        {
            return _mapper.Map<List<RoomPictureTinyDTO>>(await _roomPictureRepository.GetAllAsync());
        }
    }
}
