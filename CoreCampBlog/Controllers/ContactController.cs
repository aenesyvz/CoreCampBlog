using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;

            contactManager.Add(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
