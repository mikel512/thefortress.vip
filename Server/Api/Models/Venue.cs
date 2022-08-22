using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Venue
    {
        public Venue()
        {
            EventConcerts = new HashSet<EventConcert>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; } = null!;
        public string? Location { get; set; }
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string? Logo { get; set; }
        public string? TicketsLink { get; set; }
        public string? MenuLink { get; set; }
        public string? Hours { get; set; }
        public int CityFk { get; set; }

        public virtual City CityFkNavigation { get; set; } = null!;
        public virtual ICollection<EventConcert> EventConcerts { get; set; }
    }
}
