using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly HHContext _context;

        public ReservationRepository(HHContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountReservedAsync(Expression<Func<ReservedRoom, bool>> predicate)
        {
            return await _context.ReservedRooms.Include(x => x.Reservation).Include(x => x.Room).Where(predicate).CountAsync();
        }
    }
}
