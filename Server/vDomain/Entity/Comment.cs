using System;
using System.Collections.Generic;

namespace vInfra
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime DateStamp { get; set; }
        public int Upvotes { get; set; }
        public string UserName { get; set; } = null!;
    }
}
