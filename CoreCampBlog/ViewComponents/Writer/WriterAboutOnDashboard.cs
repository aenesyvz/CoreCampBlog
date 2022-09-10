using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreCampBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
           
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var user = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var user = writerManager.GetByMail(userMail);
            var value = writerManager.GetById(user.WriterId);
            return View(value);
        }
    }
}
