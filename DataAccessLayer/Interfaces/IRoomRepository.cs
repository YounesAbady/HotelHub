using Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        public Task<List<Room>> GetAllWithIncludeAsync(Expression<Func<Room, bool>> predicate);
    }
}
