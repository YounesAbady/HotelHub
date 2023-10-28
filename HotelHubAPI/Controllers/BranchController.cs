using APIContract.BranchDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("branches/")]
    public class BranchController : ControllerBase
    {
        private readonly IBranch _branch;

        public BranchController(IBranch branch)
        {
            _branch = branch;
        }

        [HttpGet]
        [Route("get-all-branches-tiny")]
        public async Task<List<BranchTinyDto>> GetAllTiny()
        {
            return await _branch.GetAllTinyAsync();
        }
    }
}
