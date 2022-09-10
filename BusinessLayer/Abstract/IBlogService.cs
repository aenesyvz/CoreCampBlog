using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListByWriter(int id);
        List<Blog> GetListWithCategoryByWriterId(int id);
    }
}
