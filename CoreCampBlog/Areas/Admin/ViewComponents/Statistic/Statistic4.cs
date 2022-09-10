using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreCampBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = context.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.adminImage = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.adminDescription = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
