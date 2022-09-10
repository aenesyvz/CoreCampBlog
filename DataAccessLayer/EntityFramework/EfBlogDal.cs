using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryDal<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using(var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriterId(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).Where(x=>x.WriterId == id).ToList();
            }
        }
    }
}
