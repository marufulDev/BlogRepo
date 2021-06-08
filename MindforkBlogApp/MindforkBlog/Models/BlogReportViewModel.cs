using MindforkBlog.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindforkBlog.Models
{
    public class BlogReportViewModel
    {
        public long BlogId { get; set; }
        public string Title { get; set; }
        public System.DateTime BlogCreatedDate { get; set; }
        public string AuthorName { get; set; }
        public int TotalComments { get; set; }


        public virtual List<CommentsViewModel> blogCommnets { get; set; }

    }
}