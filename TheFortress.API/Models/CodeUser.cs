using System;
using System.Collections.Generic;

namespace TheFortress.API.Models
{
    public partial class CodeUser
    {
        public int CodeId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
