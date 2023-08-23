using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using vDomain.Attributes;

namespace vDomain.Entity;

[NTypewriterIgnore]
[Table("AspNetUsers")]
public class ApplicationUser : IdentityUser
{
    public bool MailingListEnabled { get; set; }
    public bool IsFirstLogin { get; set; }
}