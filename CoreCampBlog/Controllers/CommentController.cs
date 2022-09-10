using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            commentManager.Add(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            ViewBag.BlogId = id;
            var values = commentManager.GetListByBlogId(id);
            return PartialView(values);
        }
    }
}
