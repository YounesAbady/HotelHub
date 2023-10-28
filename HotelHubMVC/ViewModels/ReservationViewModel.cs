using APIContract.RoomDTOs;
using APIContract.RoomPictureDTO;

namespace HotelHubMVC.ViewModels
{
    public record ReservationViewModel
    {
        public List<RoomTinyDTO> Rooms { get; set; } = new();
        public List<RoomPictureTinyDTO> RoomPictures { get; set; } = new();
    }
}
