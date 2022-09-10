using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
