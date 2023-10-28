using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(HHContext context) : base(context)
        {
        }
    }
}
