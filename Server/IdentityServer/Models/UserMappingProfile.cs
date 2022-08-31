using AutoMapper;
using IdentityServer.Attributes;

namespace IdentityServer.Models
{
    [NTypewriterIgnore]
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();
        }
    }
}
