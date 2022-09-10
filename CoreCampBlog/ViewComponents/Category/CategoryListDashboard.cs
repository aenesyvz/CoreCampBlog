using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCampBlog.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }
    }
}
