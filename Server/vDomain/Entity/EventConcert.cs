using System;
using System.Collections.Generic;

namespace vInfra
{
    public partial class EventConcert
    {
        public int EventConcertId { get; set; }
        public string EventName { get; set; } = null!;
        public string? Flyer { get; set; }
        public DateTime EventDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? Tickets { get; set; }
        public int? VenueFk { get; set; }
        public string? Details { get; set; }
        public string? Price { get; set; }
        public string? EventTime { get; set; }
        public string? Status { get; set; }

        public virtual Venue? VenueFkNavigation { get; set; }
    }
}
