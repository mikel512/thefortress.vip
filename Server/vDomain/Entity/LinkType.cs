using System;
using System.Collections.Generic;

namespace vDomain.Entity;

public partial class LinkType
{
    public int LinkTypeId { get; set; }
    public string LinkType1 { get; set; } = null!;
    public string? FaImgClass { get; set; }
}
