using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllNotification()
        {
            var value = notificationManager.GetAll();
            return View(value);
        }
    }
}
