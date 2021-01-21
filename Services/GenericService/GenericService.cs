using System;
using System.Linq;
using System.Linq.Expressions;
using DatabaseContext;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.GenericService
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public readonly IUnitOfWork uow;

        public GenericService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return uow.Get<T>(filter);
        }

        public T Find(object Id)
        {
            return uow.Set<T>().Find(Id);
        }

        public void Insert(T entity)
        {
            uow.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (uow.Entry(entity).State == EntityState.Detached)
            {
                uow.Set<T>().Attach(entity);
            }

            uow.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entityToDelete = uow.Set<T>().Find(id);

            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        public void Delete(T entity)
        {
            if (uow.Entry(entity).State == EntityState.Detached)
            {
                uow.Set<T>().Attach(entity);
            }
            uow.Set<T>().Remove(entity);
        }
    }
}