using APIContract.BranchDTOs;

namespace BusinessLayer.Interfaces
{
    public interface IBranch
    {
        public Task<List<BranchTinyDto>> GetAllTinyAsync();
    }
}
