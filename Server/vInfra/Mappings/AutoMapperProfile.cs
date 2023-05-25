using AutoMapper;
using vApplication.Attributes;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using vDomain.Dto;
using vInfra.Identity;

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
