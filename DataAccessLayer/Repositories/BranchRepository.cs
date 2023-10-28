using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(HHContext context) : base(context)
        {
        }
    }
}
