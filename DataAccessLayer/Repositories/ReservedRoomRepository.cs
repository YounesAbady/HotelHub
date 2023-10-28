using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer.Repositories
{
    public class ReservedRoomRepository : Repository<ReservedRoom>, IReservedRoomRepository
    {
        public ReservedRoomRepository(HHContext context) : base(context)
        {
        }
    }
}
