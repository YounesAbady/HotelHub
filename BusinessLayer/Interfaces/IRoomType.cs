using APIContract.RoomTypeDTOs;

namespace BusinessLayer.Interfaces
{
    public interface IRoomType
    {
        public Task<List<RoomTypeTinyDTO>> GetAllTinyAsync();
    }
}
