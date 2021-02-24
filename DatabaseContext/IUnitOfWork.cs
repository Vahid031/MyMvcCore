using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;

        void Commit();

        Task CommitAsync();

        EntityEntry<T> Entry<T>(T Entity) where T : class;
    }
}
