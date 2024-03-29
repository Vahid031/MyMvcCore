using ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General.MemberViewModel;

namespace Services.General.MemberService
{
    public interface IMemberService
    {
        IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg);

        CreateMemberViewModel Get(Guid Id);

        IEnumerable<Tree> Permission(Guid id, bool isDenied);

        Task InsertAsync(CreateMemberViewModel model);

        Task UpdateAsync(Guid id, CreateMemberViewModel model);

        Task DeleteAsync(Guid id);
    }
}