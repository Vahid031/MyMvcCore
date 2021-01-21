using Infrastructure.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.GenericService
{
    public interface IGenericService<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);

        T Find(object Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(object id);

        void Delete(T entity);
    }
}
