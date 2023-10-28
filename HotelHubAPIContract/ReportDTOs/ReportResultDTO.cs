using APIContract.RoomDTOs;

namespace APIContract.ReportDTOs
{
    public record ReportResultDTO
    {
        public List<RoomTinyDTO> AllRooms { get; set; } = new();
        public List<RoomTinyDTO> AvaliableRooms { get; set; } = new();
    }
}
