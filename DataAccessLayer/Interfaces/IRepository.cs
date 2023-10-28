using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T>
    {
        public Task CommitAsync();
        public Task AddAsync(T record);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
