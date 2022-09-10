using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace CoreCampBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page = 1)
        {
            var value = categoryManager.GetAll().ToPagedList(page,3);
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = categoryManager.GetById(id);
            categoryManager.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
