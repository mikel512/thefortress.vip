using System;
using System.Collections.Generic;

namespace vDomain.Entity;

public partial class Analytic
{
    public long AnalyticsId { get; set; }
    public string? IpAddress { get; set; }
    public DateTime? DateAdded { get; set; }
    public string? Location { get; set; }
}
