using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseContext;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UnitOfWork context;

        public Repository(UnitOfWork context)
        {
            this.context = context;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = context.Set<T>().AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public T Find(object Id)
        {
            return context.Set<T>().Find(Id);
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }

            context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            Parallel.ForEach(entities, entity =>
            {
                Update(entity);
            });
        }

        public void Delete(object id)
        {
            T entity = context.Set<T>().Find(id);

            if (entity != null)
                Delete(entity);
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }
            context.Set<T>().Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            Parallel.ForEach(entities, entity =>
            {
                Delete(entity);
            });
        }

        void IRepository<T>.SaveChanges(Guid? memberId)
        {
            context.Commit(memberId);
        }

        async Task IRepository<T>.SaveChangesAsync(Guid? memberId)
        {
            await context.CommitAsync(memberId);
        }
    }
}