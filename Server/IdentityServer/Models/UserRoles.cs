using Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    [NTypewriterIgnore]
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Artist = "Artist";
    }
}
