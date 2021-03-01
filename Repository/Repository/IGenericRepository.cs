using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);

        T Find(object Id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(object id);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}
