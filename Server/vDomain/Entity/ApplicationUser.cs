using Microsoft.AspNetCore.Identity;
using vDomain.Attributes;

namespace vDomain.Entity;

[NTypewriterIgnore]
public class ApplicationUser : IdentityUser
{
    public bool MailingListEnabled { get; set; }
    public bool IsFirstLogin { get; set; }
}