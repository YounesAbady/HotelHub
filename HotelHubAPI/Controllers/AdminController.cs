using APIContract.LoginDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpPost]
        [Route("login")]
        public async Task<int> Login([FromBody] LoginSendDTO loginSendDTO)
        {
            return await _adminServices.LoginAsync(loginSendDTO);
        }
    }
}
