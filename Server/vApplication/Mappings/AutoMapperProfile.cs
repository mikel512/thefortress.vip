using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using vDomain.Dto;
using vApplication.Dto;
using vDomain.Identity;
using vDomain.Attributes;

namespace vApplication.Mappings;

[NTypewriterIgnore]
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegistrationDto, ApplicationUser>();
        CreateMap<AppUserDto, ApplicationUser>();
        CreateMap<ApplicationUser, AppUserDto>();
        CreateMap<Claim, UserClaimDto>();
    }
}
