using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryDal<Message>, IMessageDal
    {

    }
}
