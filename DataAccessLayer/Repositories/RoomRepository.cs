using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly HHContext _context;

        public RoomRepository(HHContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllWithIncludeAsync(Expression<Func<Room, bool>> predicate)
        {
            return await _context.Rooms.Where(predicate).Include(x => x.RoomType).ToListAsync();
        }
    }
}
