using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var value = notificationManager.GetAll().Where(x=>x.NotificationStatus == true).OrderByDescending(x=>x.NotificationDate).Take(3).ToList();
            return View(value);
        }
    }
}
