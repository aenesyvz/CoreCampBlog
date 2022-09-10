using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreCampBlog.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var value = blogManager.GetListWithCategory().Take(10).OrderByDescending(x=>x.BlogCreateDate).ToList();
            return View(value);
        }
    }
}
