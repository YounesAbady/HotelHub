using APIContract.LoginDTOs;

namespace BusinessLayer.Interfaces
{
    public interface IAdminServices
    {
        public Task<int> LoginAsync(LoginSendDTO loginSendDTO);
    }
}
