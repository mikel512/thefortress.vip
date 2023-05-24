namespace IdentityServer.Models
{
    public class UserClaimDto
    {
        public const string CITY = "CITY";
        public const string VENUE= "VENUE";

        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
