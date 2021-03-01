using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();

        void AuditAllChangeTracking(Guid memberId);

        void AuditEntry<T>(T entity, Guid memberId);
    }
}
