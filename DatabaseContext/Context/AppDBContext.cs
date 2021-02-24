using Microsoft.EntityFrameworkCore;
using DomainModels.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using DatabaseContext.Extentions;

namespace DatabaseContext.Context
{
    public class AppDBContext : DbContext, IUnitOfWork
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

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIndexes();

            modelBuilder.Seed();
        }

        public void Commit()
        {
            ApplyDefaultValues();

            base.SaveChanges();
            //using (var scope = Database.BeginTransaction())
            //{
            //    try
            //    {
            //        base.SaveChanges();

            //        if (memberId != null)
            //        {
            //            foreach (EntityEntry entry in ChangeTracker.Entries())
            //                ApplyAuditLog(entry, memberId.Value);

            //            base.SaveChanges();
            //        }

            //        scope.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        scope.Rollback();
            //    }
            //}
        }

        public async Task CommitAsync()
        {
            ApplyDefaultValues();

            await base.SaveChangesAsync();
            //using (var scope = Database.BeginTransaction())
            //{
            //    try
            //    {
            //        base.SaveChanges();

            //        if (memberId != null)
            //        {
            //            foreach (EntityEntry entry in ChangeTracker.Entries())
            //                ApplyAuditLog(entry, memberId.Value);

            //            base.SaveChanges();
            //        }

            //        await scope.CommitAsync();
            //    }
            //    catch (Exception)
            //    {
            //        await scope.RollbackAsync();
            //    }
            //}
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
    }
}
