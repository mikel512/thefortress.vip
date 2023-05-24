using System;
using System.Collections.Generic;

namespace vInfra
{
    public partial class City
    {
        public City()
        {
            Venues = new HashSet<Venue>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }
    }
}
