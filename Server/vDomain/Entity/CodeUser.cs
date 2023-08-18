using System;
using System.Collections.Generic;

namespace vDomain.Entity;

public partial class CodeUser
{
    public int CodeId { get; set; }
    public string UserId { get; set; } = null!;
}
