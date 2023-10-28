using APIContract.LoginDTOs;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models;

namespace BusinessLayer.Implementations
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<int> LoginAsync(LoginSendDTO loginSendDTO)
        {
            Admin logged = await _adminRepository.FirstOrDefaultAsync(x => x.Username == loginSendDTO.Username && x.IsActive);
            if (logged != null)
            {
                var hasher = new PasswordHasher<Admin>();
                //var x = hasher.HashPassword(logged, loginSendDTO.Password);
                if (hasher.VerifyHashedPassword(logged, logged.HashedPassword, loginSendDTO.Password).Equals(PasswordVerificationResult.Success))
                {
                    return 1;
                }
                else
                    throw new ApplicationException("Wrong password!");
            }
            else
                throw new ApplicationException("User not found!");
        }
    }
}
