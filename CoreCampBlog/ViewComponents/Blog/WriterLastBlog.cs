using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = blogManager.GetListByWriter(id);
            return View(values);
        }
    }


}
