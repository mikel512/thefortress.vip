using Microsoft.AspNetCore.Identity;
using vDomain.Dto;

namespace vApplication.Interface;

public interface IUserAuthService
{
    Task<IdentityResult> RegisterUserAsync(RegistrationDto user);
    Task<bool> ValidateUserAsync(LoginDto loginDto);
    Task<string> CreateTokenAsync();
    Task<IdentityResult> ConfirmEmailAsync(string userId, string code);
    Task<IdentityResult> SendPasswordResetAsync(string email);
    Task<IdentityResult> ResetPasswordAsync(string email, string code, string password);
}
