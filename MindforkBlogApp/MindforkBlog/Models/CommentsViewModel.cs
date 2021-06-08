using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindforkBlog.Models
{
    public class CommentsViewModel
    {
        public long CommentId { get; set; }
        public string CommentContent { get; set; }
        public Nullable<long> CommentLike { get; set; }
        public Nullable<long> CommentDislike { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Commenter { get; set; }

    }
}