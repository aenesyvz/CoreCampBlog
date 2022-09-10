using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(b =>b.BlogId == id);
        }

        public List<Blog> GetListByWriter(int id)
        {
            return _blogDal.GetAll(w => w.WriterId == id);
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterId(int id)
        {
            return _blogDal.GetListWithCategoryByWriterId(id);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
