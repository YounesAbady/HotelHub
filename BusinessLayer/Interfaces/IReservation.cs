using APIContract.ReservationDTOs;
using APIContract.RoomDTOs;

namespace BusinessLayer.Interfaces
{
    public interface IReservation
    {
        public Task<List<RoomTinyDTO>> GetAllAvaliableRoomsAsync(ReservationSearchDTO reservationSearchDTO);
    }
}
