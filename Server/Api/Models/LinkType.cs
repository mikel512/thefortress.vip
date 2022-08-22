using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class LinkType
    {
        public int LinkTypeId { get; set; }
        public string LinkType1 { get; set; } = null!;
        public string? FaImgClass { get; set; }
    }
}
