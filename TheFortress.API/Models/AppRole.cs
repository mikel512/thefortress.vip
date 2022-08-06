using System;
using System.Collections.Generic;

namespace TheFortress.API.Models
{
    public partial class AppRole
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
