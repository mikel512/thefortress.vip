﻿using Microsoft.AspNetCore.Identity;
using vDomain.Dto;

namespace IdentityServer.Services
{
    public interface IUserAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegistrationDto user);
        Task<bool> ValidateUserAsync(LoginDto loginDto);
        Task<string> CreateTokenAsync();
        Task<IActionResult> ConfirmEmailAsync(string userId, string code);
        Task<IActionResult> SendPasswordResetAsync(string email);
        Task<IActionResult> ResetPasswordAsync(string email, string code, string password);
    }
}
