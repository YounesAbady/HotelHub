using APIContract.BranchDTOs;
using APIContract.LoginDTOs;
using APIContract.ReservationDTOs;
using APIContract.RoomTypeDTOs;

namespace HotelHubMVC.ViewModels
{
    public record HomeViewModel
    {
        public List<BranchTinyDto> Branches { get; set; } = new();
        public List<RoomTypeTinyDTO> RoomTypes { get; set; } = new();
        public ReservationSearchDTO ReservationSearchDTO { get; set; } = new();
        public LoginSendDTO LoginDTO { get; set; } = new();
    }
}
