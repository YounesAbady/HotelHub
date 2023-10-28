using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer.Repositories
{
    public class RoomPictureRepository : Repository<RoomPicture>, IRoomPicturesRepository
    {
        public RoomPictureRepository(HHContext context) : base(context)
        {
        }
    }
}
