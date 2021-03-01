using DatabaseContext.Context;
using DomainModels.General;

namespace Repository.General
{
    public interface IMemberPermissionRepository : IGenericRepository<MemberPermission>
    {

    }

    public class MemberPermissionRepository : GenericRepository<MemberPermission>, IMemberPermissionRepository
    {
        public MemberPermissionRepository(IAppDbContext unitOfWork) : base(unitOfWork) { }
    }
}
