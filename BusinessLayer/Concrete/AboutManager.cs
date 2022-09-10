using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(a =>a.AboutId == id);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
