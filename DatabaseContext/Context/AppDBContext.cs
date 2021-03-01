using Microsoft.EntityFrameworkCore;
using DomainModels.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using DatabaseContext.Extentions;
using System.Threading;
using System.Collections.Generic;

namespace DatabaseContext.Context
{
    public class AppDBContext : DbContext, IAppDbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberPermission> MemberPermissions { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddIndexes();

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        IEnumerable<EntityEntry> IAppDbContext.ChangeTrackerEntries => ChangeTracker.Entries();

        public override int SaveChanges() => base.SaveChanges(true);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(true, cancellationToken);
    }
}
