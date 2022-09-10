using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = blogManager.GetListWithCategory();
            return View(values);
        }
        public IActionResult BlogDetails(int id)
        {
            var values = blogManager.GetById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var user = writerManager.GetByMail(userMail);
            var value = blogManager.GetListWithCategoryByWriterId(user.WriterId);
            return View(value);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var user = writerManager.GetByMail(userMail);

            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(blog);
            if (results.IsValid)
            {
              
                blog.WriterId = user.WriterId;
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blogManager.Add(blog);
                return RedirectToAction("BlogListWriter", "Blog");
            }
            foreach(var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var value = blogManager.GetById(id);
            blogManager.Delete(value);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = blogManager.GetById(id);
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;
            return View(value);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var user = writerManager.GetByMail(userMail);
            blog.WriterId = user.WriterId;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
