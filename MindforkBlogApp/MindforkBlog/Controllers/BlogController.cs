using MindforkBlog.Infrastructure.Model;
using MindforkBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MindforkBlog.Controllers
{
    public class BlogController : ApiController
    {

        BlogDBEntities db;
        public BlogController()
        {
            db = new BlogDBEntities();
        }
        // GET: api/BlogReport/2/1
        [HttpGet]
        public List<BlogReportViewModel> BlogReport(int pageSize, int pageNumber, string searchText)
        {
            List<BlogReportViewModel> blogReportViewModels = new List<BlogReportViewModel>();
            List<CommentsViewModel> commentsViewModels = new List<CommentsViewModel>();

            List<Blog> blogs = db.Blogs.Where(x=>x.Title.Contains(searchText) || String.IsNullOrEmpty(searchText)).OrderByDescending(x => x.BlogId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            foreach(Blog blog in blogs)
            {
                BlogReportViewModel model = new BlogReportViewModel
                {
                    Title = blog.Title,
                    TotalComments = blog.Comments.Count(),
                    AuthorName = blog.User.UserName,
                    BlogCreatedDate = blog.CreatedDate,
                };
                // Binding Comment data
                foreach (Comment comment in blog.Comments)
                {
                    CommentsViewModel cblogReportViewModels=new CommentsViewModel
                    {
                        CommentId = comment.CommentId,
                        CommentContent = comment.CommentContent,
                        CommentLike = comment.CommentLike,
                        CommentDislike = comment.CommentDislike,
                        CreatedDate = comment.CreatedDate,
                        Commenter = comment.User.UserName
                    };
                    commentsViewModels.Add(cblogReportViewModels);
                }
                model.blogCommnets = commentsViewModels;
                blogReportViewModels.Add(model);
                commentsViewModels = new List<CommentsViewModel>();
            }
            return blogReportViewModels;

        }
    }
}
