using APIContract.ReservationDTOs;
using APIContract.RoomDTOs;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class Reservation : IReservation
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoom _roomServices;
        private readonly IMapper _mapper;

        public Reservation(IReservationRepository reservationRepository, IMapper mapper, IRoom room)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _roomServices = room;
        }

        public async Task<List<RoomTinyDTO>> GetAllAvaliableRoomsAsync(ReservationSearchDTO reservationSearchDTO)
        {
            if (reservationSearchDTO == null || reservationSearchDTO.BranchId == null || reservationSearchDTO.BranchId == Guid.Empty)
            {
                throw new ApplicationException("Enter Valid Search Data.");
            }
            List<RoomTinyDTO> allRooms = await _roomServices.GetAllWithIncludeAsync(reservationSearchDTO.BranchId, reservationSearchDTO.Adults, reservationSearchDTO.Childrens);
            foreach (RoomTinyDTO room in allRooms)
            {
                room.Quantity -= await _reservationRepository.CountReservedAsync(x => x.Reservation.BranchId == reservationSearchDTO.BranchId
                                                                                && x.Reservation.StartDate < reservationSearchDTO.EndDate
                                                                                && x.Reservation.EndDate > reservationSearchDTO.StartDate
                                                                                && x.Room.RoomType.RoomType == room.RoomType.RoomType);
            }
            return _mapper.Map<List<RoomTinyDTO>>(allRooms);
        }
    }
}
