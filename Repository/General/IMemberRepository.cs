using DatabaseContext;
using DomainModels.General;

namespace Repository.General
{
    public interface IMemberRepository : IBaseRepository<Member>
    {

    }

    public class MemberRepository : BaseRepository<Member>
    {
        public MemberRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
