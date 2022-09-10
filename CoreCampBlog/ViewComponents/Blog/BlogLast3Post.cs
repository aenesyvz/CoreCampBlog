using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.ViewComponents.Blog
{
    public class BlogLast3Post:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var value = blogManager.GetAll().Take(3).ToList();
            return View(value);
        }
    }
}
