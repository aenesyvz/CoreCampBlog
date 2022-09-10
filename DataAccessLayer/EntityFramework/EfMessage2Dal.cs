using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Dal : EfEntityRepositoryDal<Message2>, IMessage2Dal
    {
        public List<Message2> GetAllWithMessageByWriter(int id)
        {
            using(var context = new Context())
            {
                return context.Message2s.Include(x => x.SenderUser).Where(x => x.RecevierId == id).ToList();
            }
        }
    }
}
