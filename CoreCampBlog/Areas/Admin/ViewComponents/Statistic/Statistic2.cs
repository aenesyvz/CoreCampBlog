using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreCampBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.recentBlog = context.Blogs.OrderByDescending(x => x.BlogId).Select(y=>y.BlogTitle).FirstOrDefault();
            return View();
        }
    }
}
