using AutoMapper;
using Common.Attributes;

namespace IdentityServer.Models
{
    [NTypewriterIgnore]
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();
            CreateMap<AppUserDto, ApplicationUser>();
        }
    }
}
