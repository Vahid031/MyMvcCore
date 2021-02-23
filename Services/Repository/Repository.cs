using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class Repository : IRepository
    {
        public readonly IUnitOfWork uow;

        public Repository(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> query = uow.Set<T>().AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public T Find<T>(object Id) where T : class
        {
            return uow.Set<T>().Find(Id);
        }

        public void Insert<T>(T entity) where T : class
        {
            uow.Set<T>().Add(entity);
        }

        public void Insert<T>(IEnumerable<T> entities) where T : class
        {
            uow.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            if (uow.Entry(entity).State == EntityState.Detached)
            {
                uow.Set<T>().Attach(entity);
            }

            uow.Entry(entity).State = EntityState.Modified;
        }

        public void Update<T>(IEnumerable<T> entities) where T : class
        {
            Parallel.ForEach(entities, entity =>
            {
                Update(entity);
            });
        }

        public void Delete<T>(object id) where T : class
        {
            T entity = Find<T>(id);

            if (entity != null)
                Delete(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            if (uow.Entry(entity).State == EntityState.Detached)
            {
                uow.Set<T>().Attach(entity);
            }
            uow.Set<T>().Remove(entity);
        }

        public void Delete<T>(IEnumerable<T> entities) where T : class
        {
            Parallel.ForEach(entities, entity => {
                Delete(entity);
            });           
        }
    }
}