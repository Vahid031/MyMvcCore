using DatabaseContext.Context;
using DomainModels.General;

namespace Repository.General
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {

    }

    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(IAppDbContext unitOfWork) : base(unitOfWork) { }
    }
}
