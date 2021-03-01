using DatabaseContext.Context;
using DomainModels.General;

namespace Repository.General
{
    public interface IMemberRepository : IGenericRepository<Member>
    {

    }

    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(IAppDbContext unitOfWork) : base(unitOfWork) { }
    }
}
