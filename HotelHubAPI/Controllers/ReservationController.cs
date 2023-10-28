using APIContract.ReservationDTOs;
using APIContract.RoomDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("reservations/")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservation _reservationServices;

        public ReservationController(IReservation reservation)
        {
            _reservationServices = reservation;
        }

        [HttpPost]
        [Route("get-avaliable-rooms")]
        public async Task<List<RoomTinyDTO>> GetAvaliableRooms([FromBody] ReservationSearchDTO reservationSearchDTO)
        {
            return await _reservationServices.GetAllAvaliableRoomsAsync(reservationSearchDTO);
        }
    }
}
