using APIContract.RoomPictureDTO;
using APIContract.RoomTypeDTOs;
using Models;

namespace APIContract.RoomDTOs
{
    public record RoomTinyDTO : RoomBaseDTO
    {
        public string RoomName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid RoomTypeId { get; set; }
        public RoomsType? RoomType { get; set; }
        public List<RoomPictureTinyDTO>? RoomPictures { get; set; }
    }
}
