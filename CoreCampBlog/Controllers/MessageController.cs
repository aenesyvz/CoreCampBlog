using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Dal());
        Context context = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var value = messageManager.GetAllByWriter(writerId);
            return View(value);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = messageManager.GetById(id);
            return View(value);
        }
    }
}
