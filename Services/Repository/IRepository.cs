using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public interface IRepository 
    {
        IQueryable<T> Get<T>(Expression<Func<T, bool>> filter = null) where T : class;

        T Find<T>(object Id) where T : class;

        void Insert<T>(T entity) where T : class;

        void Insert<T>(IEnumerable<T> entities) where T : class;

        void Update<T>(T entity) where T : class;

        void Update<T>(IEnumerable<T> entities) where T : class;

        void Delete<T>(object id) where T : class;

        void Delete<T>(T entity) where T : class;

        void Delete<T>(IEnumerable<T> entities) where T : class;
    }
}
