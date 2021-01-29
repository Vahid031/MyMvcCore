using Microsoft.EntityFrameworkCore;
using DomainModels.General;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Infrastructure.Common;
using DatabaseContext.Extentions;

namespace DatabaseContext.Context
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<MemberPermission> MemberPermissions { get; set; }

        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIndexes();

            modelBuilder.Seed();
        }
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public UnitOfWork Context
        {
            get
            {
                return this;
            }
        }

        public void Commit(Guid? memberId)
        {
            ApplyDefaultValues();

            using (var scope = Database.BeginTransaction())
            {
                try
                {
                    base.SaveChanges();

                    if (memberId != null)
                    {
                        foreach (EntityEntry entry in ChangeTracker.Entries())
                            ApplyAuditLog(entry, memberId.Value);

                        base.SaveChanges();
                    }

                    scope.Commit();
                }
                catch (Exception)
                {
                    scope.Rollback();
                }
            }
        }

        public async Task CommitAsync(Guid? memberId)
        {
            ApplyDefaultValues();

            using (var scope = Database.BeginTransaction())
            {
                try
                {
                    await base.SaveChangesAsync();

                    if (memberId != null)
                    {
                        foreach (EntityEntry entry in ChangeTracker.Entries())
                            ApplyAuditLog(entry, memberId.Value);

                        await base.SaveChangesAsync();
                    }

                    await scope.CommitAsync();
                }
                catch (Exception)
                {
                    await scope.RollbackAsync();
                }
            }
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
                    .Where(m => ExtensionMethod.predefinedTypes.Any(i => i.Name == m.PropertyType.Name)), item =>
                    {
                        LogDetail logDetail = new LogDetail()
                        {
                            PropertyName = item.Name,
                            PropertyValue = item.GetValue(entry.Entity)?.ToString()
                        };
                        log.LogDetails.Add(logDetail);
                    });

                Logs.Add(log);
            }
        }

        private void ApplyDefaultValues()
        {
            DefaultValueAttribute defaultValue;

            foreach (EntityEntry entry in ChangeTracker.Entries())
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

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> query = base.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }
    }
}
