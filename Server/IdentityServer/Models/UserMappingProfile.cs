using AutoMapper;

namespace IdentityServer.Models
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegistrationDTO, ApplicationUser>();
        }
    }
}
