using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IEntityRepositoryDal<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriterId(int id);
    }
}
