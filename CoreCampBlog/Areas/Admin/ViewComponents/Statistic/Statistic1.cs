using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreCampBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = blogManager.GetAll().Count();
            ViewBag.newMessageCount = context.Message2s.Count();
            ViewBag.commentCount = context.Comments.Count();


            string api = "2134448fdd97fbf056efac52a7f2f4ad";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=tosya&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.data = document.Descendants("temperature ").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
