using APIContract.RoomDTOs;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLayer.Implementations
{
    public class Room : IRoom
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public Room(IRoomRepository roomRepository, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomTinyDTO>> GetAllWithIncludeAsync(Guid id, int Adults, int Childs)
        {
            return _mapper.Map<List<RoomTinyDTO>>(await _roomRepository.GetAllWithIncludeAsync(x => x.BranchId == id && x.IsActive && x.RoomType.MaxCapacityAdults >= Adults && x.RoomType.MaxCapacityChilds >= Childs));
        }
    }
}
