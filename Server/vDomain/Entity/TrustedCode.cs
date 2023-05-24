using System;
using System.Collections.Generic;

namespace vInfra
{
    public partial class TrustedCode
    {
        public int TrustedCodeId { get; set; }
        public string CodeString { get; set; } = null!;
        public int TimesUsed { get; set; }
        public int? MaxTimesUsed { get; set; }
    }
}
