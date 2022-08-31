﻿using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegistrationDto user);
        Task<bool> ValidateUserAsync(LoginDto loginDto);
        Task<string> CreateTokenAsync();
    }
}
