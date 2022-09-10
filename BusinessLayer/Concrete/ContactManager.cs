using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Add(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(c => c.ContactId == id);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
