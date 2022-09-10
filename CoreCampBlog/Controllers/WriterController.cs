using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreCampBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var value = User.Identity.Name;
            ViewBag.user = value;
            
            return View();
        }
        [Authorize]
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
         
            
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.Mail = values.Email;
            userUpdateViewModel.NameSurname = values.NameSurname;
            userUpdateViewModel.ImageUrl = values.ImageUrl;
            userUpdateViewModel.UserName = values.UserName;
            return View(userUpdateViewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            values.Email = userUpdateViewModel.Mail;
            values.NameSurname = userUpdateViewModel.NameSurname;
            values.ImageUrl = userUpdateViewModel.ImageUrl;
            values.UserName = userUpdateViewModel.UserName;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdateViewModel.Password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
            
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if(addProfileImage.WriterImage != null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = addProfileImage.WriterAbout;
            writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }

        
    }
}
