using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using DatabaseContext;
using ViewModels.General.MemberViewModel;
using Infrastructure.Entities;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Services.General.MemberService
{

    public class MemberService : Repository, IMemberService
    {
        public MemberService(IUnitOfWork uow)
        : base(uow)
        {
        }

        public IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg)
        {
            var query = Get<Person>().Select(m => new { Person = m }).Paging(list, ref pg);

            return query.AsEnumerable().Select(Result => new ListMemberViewModel()
            {
                Person = Result.Person
            });
        }

        public CreateMemberViewModel Get(Guid Id)
        {
            var query = Get<Member>(m => m.PersonId == Id).Include(m => m.Person);


            return query.AsEnumerable().Select(Result => new CreateMemberViewModel()
            {
                Member = Result,
                Person = Result.Person
            }).FirstOrDefault();
        }

        public IEnumerable<Tree> Permission(Guid id, bool isDenied)
        {
            var member = Get<MemberPermission>()
                            .AsQueryable()
                            .Where(m => id == m.MemberId)
                            .Where(m => m.IsDenied == isDenied)
                            .ToList();

            return Get<Permission>().AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id,
                parentId = Result.ParentId,
                @checked = member.Any(m => m.PermissionId == Result.Id),
                disabled = false,
                icon = Result.Icon,
                order = Result.Order,
                title = Result.Title
            });
        }

        public async Task InsertAsync(CreateMemberViewModel model)
        {

            Insert(model.Member);
            await uow.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, CreateMemberViewModel model)
        {

            Update(model.Member);
            await uow.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();

            Delete<Person>(id);

            await uow.CommitAsync();
        }
    }
}
