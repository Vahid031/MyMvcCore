using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseContext.Context;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IAppDbContext unitOfWork;

        public GenericRepository(IAppDbContext unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = unitOfWork.Set<T>().AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public T Find(object Id)
        {
            return unitOfWork.Set<T>().Find(Id);
        }

        public void Insert(T entity)
        {
            unitOfWork.Set<T>().Add(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            unitOfWork.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            if (unitOfWork.Entry(entity).State == EntityState.Detached)
            {
                unitOfWork.Set<T>().Attach(entity);
            }

            unitOfWork.Entry(entity).State = EntityState.Modified;
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
            T entity = unitOfWork.Set<T>().Find(id);

            if (entity != null)
                Delete(entity);
        }

        public void Delete(T entity)
        {
            if (unitOfWork.Entry(entity).State == EntityState.Detached)
            {
                unitOfWork.Set<T>().Attach(entity);
            }
            unitOfWork.Set<T>().Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            Parallel.ForEach(entities, entity =>
            {
                Delete(entity);
            });
        }
    }
}