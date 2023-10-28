using APIContract.RoomTypeDTOs;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class RoomType : IRoomType
    {
        private IRoomTypeRepository _roomTypeRepository;
        private IMapper _mapper;

        public RoomType(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<List<RoomTypeTinyDTO>> GetAllTinyAsync()
        {
            return _mapper.Map<List<RoomTypeTinyDTO>>(await _roomTypeRepository.WhereAsync(x => x.IsActive));
        }
    }
}
