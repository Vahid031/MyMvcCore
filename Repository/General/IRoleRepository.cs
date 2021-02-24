using DatabaseContext;
using DomainModels.General;

namespace Repository.General
{
    public interface IRoleRepository : IBaseRepository<Role>
    {

    }

    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
