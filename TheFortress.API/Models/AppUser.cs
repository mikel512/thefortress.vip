using System;
using System.Collections.Generic;

namespace TheFortress.API.Models
{
    public partial class AppUser
    {
        public long UserId { get; set; }
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ObjectId { get; set; }
    }
}
