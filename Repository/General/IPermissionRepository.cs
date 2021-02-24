using DatabaseContext;
using DomainModels.General;

namespace Repository.General
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {

    }

    public class PermissionRepository : BaseRepository<Permission>
    {
        public PermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
