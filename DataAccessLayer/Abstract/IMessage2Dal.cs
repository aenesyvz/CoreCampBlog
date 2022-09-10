using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IEntityRepositoryDal<Message2>
    {
        List<Message2> GetAllWithMessageByWriter(int id);
    }
}
