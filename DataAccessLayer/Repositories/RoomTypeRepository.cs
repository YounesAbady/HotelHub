using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer.Repositories
{
    public class RoomTypeRepository : Repository<RoomsType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HHContext context) : base(context)
        {
        }
    }
}
