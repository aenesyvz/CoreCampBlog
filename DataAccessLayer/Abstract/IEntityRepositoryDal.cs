﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEntityRepositoryDal<T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Expression<Func<T,bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
    }
}
