using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegistrationDTO user);
        Task<bool> ValidateUserAsync(LoginDTO loginDto);
        Task<string> CreateTokenAsync();
    }
}
