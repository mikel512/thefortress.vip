using Microsoft.AspNetCore.Identity;
using vDomain.Attributes;

namespace vDomain.Identity;

[NTypewriterIgnore]
public class ApplicationUser : IdentityUser
{
    public bool MailingListEnabled { get; set; }
    public bool IsFirstLogin { get; set; }
}