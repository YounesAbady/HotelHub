using Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        public Task<int> CountReservedAsync(Expression<Func<ReservedRoom, bool>> predicate);
    }
}
