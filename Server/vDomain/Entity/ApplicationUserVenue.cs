using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vDomain.Entity;

/// <summary>
/// Many to Many entity holding relationships of which users can edit which Venues
/// </summary>
public class ApplicationUserVenue : BaseEntity
{
    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; }

    [ForeignKey("Venue")]
    public int VenueId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual Venue Venue { get; set; }
}