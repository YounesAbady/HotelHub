using APIContract.RoomPictureDTO;

namespace BusinessLayer.Interfaces
{
    public interface IRoomPictureServices
    {
        public Task<List<RoomPictureTinyDTO>> GetAllRoomPictures();
    }
}
