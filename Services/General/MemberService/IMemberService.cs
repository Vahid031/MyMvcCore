using DomainModels.General;
using Infrastructure.Entities;
using Services.GenericService;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General.MemberViewModel;

namespace Services.General.MemberService
{
    public interface IMemberService : IGenericService<Member>
    {
        IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg);

        CreateMemberViewModel Get(int Id);

        IEnumerable<Tree> Permission(int id, bool isDenied);

        Task<Response> Save(CreateMemberViewModel model);

        Task<Response> Remove(int id);
    }
}