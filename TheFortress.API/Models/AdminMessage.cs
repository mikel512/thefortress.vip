using System;
using System.Collections.Generic;

namespace TheFortress.API.Models
{
    public partial class AdminMessage
    {
        public int AdminMessageId { get; set; }
        public string Sender { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string Subject { get; set; } = null!;
    }
}
