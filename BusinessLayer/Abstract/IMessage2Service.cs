using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetAllByWriter(int id);
    }
}
