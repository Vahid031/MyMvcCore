using System;
using System.Threading.Tasks;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseContext
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;

        void Commit(Guid? memberId = null);

        Task CommitAsync(Guid? memberId = null);

        EntityEntry<T> Entry<T>(T Entity) where T : class;

        UnitOfWork Context { get; }
    }
}
