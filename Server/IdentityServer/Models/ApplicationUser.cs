// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Common.Attributes;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models;

[NTypewriterIgnore]
public class ApplicationUser : IdentityUser
{
    public bool MailingListEnabled { get; set; }    
}
