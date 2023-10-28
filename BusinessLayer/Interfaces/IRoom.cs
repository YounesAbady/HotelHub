using APIContract.RoomDTOs;
using System.Linq.Expressions;

namespace BusinessLayer.Interfaces
{
    public interface IRoom
    {
        public Task<List<RoomTinyDTO>> GetAllWithIncludeAsync(Guid id, int Adults, int Childs);
    }
}
