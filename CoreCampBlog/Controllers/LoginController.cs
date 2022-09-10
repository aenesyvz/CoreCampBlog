using CoreCampBlog.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel userSignInViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignInViewModel.UserName, userSignInViewModel.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
            //Context context = new Context();
            //var value = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            //if(value != null)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name,writer.WriterMail)
            //    };
            //    var userIdentity = new ClaimsIdentity(claims, "a");
            //    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //    await HttpContext.SignInAsync(principal);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Idnex", "Login");
        }
    }
}
