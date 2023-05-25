using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vApplication.Attributes;

namespace vInfra.Identity;

[NTypewriterIgnore]
public class ApplicationUser : IdentityUser
{
    public bool MailingListEnabled { get; set; }
    public bool IsFirstLogin { get; set; }
}