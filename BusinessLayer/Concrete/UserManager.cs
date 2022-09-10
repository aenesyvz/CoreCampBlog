using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(AppUser entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(AppUser entity)
        {
            _userDal.Delete(entity);
        }

        public List<AppUser> GetAll()
        {
            return _userDal.GetAll();
        }

        public AppUser GetById(int id)
        {
            return _userDal.GetById(x => x.Id == id);
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
