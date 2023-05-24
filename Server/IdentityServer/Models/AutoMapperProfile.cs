using AutoMapper;
using Common.Attributes;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Models
{
    [NTypewriterIgnore]
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();
            CreateMap<AppUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, AppUserDto>();
            CreateMap<Claim, UserClaimDto>();
        }
    }
}
