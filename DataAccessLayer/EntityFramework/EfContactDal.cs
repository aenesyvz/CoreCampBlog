using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryDal<Contact>, IContactDal
    {

    }
}
