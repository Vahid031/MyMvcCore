using DatabaseContext.Context;
using DomainModels;
using DomainModels.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext appDbContext;

        public UnitOfWork(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AuditAllChangeTracking(Guid memberId)
        {
            foreach (EntityEntry entry in appDbContext.ChangeTrackerEntries)
                ApplyAuditLog(entry, memberId);
        }

        public void AuditEntry<T>(T entity, Guid memberId)
        {
            EntityEntry entry = appDbContext.ChangeTrackerEntries.FirstOrDefault(m => m.Entity.Equals(entity));

            if (entity != null)
                ApplyAuditLog(entry, memberId);
        }

        public int Commit()
        {
          return  appDbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

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
                    //.Where(m => m.PropertyType.isa(m, typeof(BaseEntity))
                    ,
                    item =>
                    {
                        LogDetail logDetail = new LogDetail()
                        {
                            Key = item.Name,
                            Value = item.GetValue(entry.Entity)?.ToString()
                        };
                        log.LogDetails.Add(logDetail);
                    });

                appDbContext.Set<Log>().Add(log);
            }
        }

        private void ApplyDefaultValues()
        {
            DefaultValueAttribute defaultValue;

            foreach (EntityEntry entry in appDbContext.ChangeTrackerEntries)
            {
                foreach (var prop in entry.Entity.GetType().GetProperties())
                {
                    defaultValue = (DefaultValueAttribute)prop.GetCustomAttribute(typeof(DefaultValueAttribute), false);

                    var key = (KeyAttribute)prop.GetCustomAttribute(typeof(KeyAttribute), false);

                    if (prop.GetValue(entry.Entity) == null)
                        prop.SetValue(entry.Entity, defaultValue?.Value);
                }
            }
        }
    }
}
