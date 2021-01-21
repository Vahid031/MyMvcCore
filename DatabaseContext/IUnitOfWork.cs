using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public interface IUnitOfWork
    {

        DbSet<T> Set<T>() where T : class;

        void Commit(int? memberId = null);

        Task CommitAsync(int? memberId = null);

        EntityEntry<T> Entry<T>(T Entity) where T : class;

        UnitOfWork Context { get; }

        IQueryable<T> Get<T>(Expression<Func<T, bool>> filter = null) where T : class;
    }
}
