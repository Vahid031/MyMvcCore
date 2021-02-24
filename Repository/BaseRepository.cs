using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DatabaseContext;
using DomainModels;
using DomainModels.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
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

        private void ApplyAuditLog(EntityEntry entry, Guid memberId)
        {
            var rowId = (Guid?)entry.Entity.GetType().GetProperties().Where(e => Attribute.IsDefined(e, typeof(KeyAttribute))).Select(p => p.GetValue(entry.Entity)).FirstOrDefault();

            if (rowId != null)
            {
                Log log = new Log()
                {
                    MemberId = memberId,
                    TableName = entry.Entity.GetType().Name,
                    State = (byte)entry.State,
                    Date = DateTime.Now,
                    RowId = rowId,
                    LogDetails = new List<LogDetail>()
                };


                Parallel.ForEach(entry.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => !Attribute.IsDefined(m, typeof(KeyAttribute)))
                    .Where(m => !Attribute.IsDefined(m, typeof(NotMappedAttribute)))
                    .Where(m => ExtentionMethods.predefinedTypes.Any(i => i.Name == m.PropertyType.Name)), item =>
                    {
                        LogDetail logDetail = new LogDetail()
                        {
                            PropertyName = item.Name,
                            PropertyValue = item.GetValue(entry.Entity)?.ToString()
                        };
                        log.LogDetails.Add(logDetail);
                    });

                unitOfWork.Set<Log>().Add(log);
            }
        }
    }
}