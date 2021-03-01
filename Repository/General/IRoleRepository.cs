using DatabaseContext.Context;
using DomainModels.General;

namespace Repository.General
{
    public interface IRoleRepository : IGenericRepository<Role>
    {

    }

    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IAppDbContext unitOfWork) : base(unitOfWork) { }
    }
}
