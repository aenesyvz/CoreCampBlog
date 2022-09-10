using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
    
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
