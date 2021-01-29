using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using DatabaseContext;
using ViewModels.General.MemberViewModel;
using Infrastructure.Entities;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Services.GenericService;
using System.Threading.Tasks;
using System;
using Infrastructure.Enums;
using Services.UserService;

namespace Services.General.MemberService
{

    public class MemberService : GenericService<Member>, IMemberService
    {
        private readonly IUserService userService;

        public MemberService(IUnitOfWork uow, IUserService userService)
            : base(uow)
        {
            this.userService = userService;
        }

        public IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg)
        {
            var query = uow.Get<Person>().Select(m => new { Person = m }).Paging(list, ref pg);

            return query.AsEnumerable().Select(Result => new ListMemberViewModel()
            {
                Person = Result.Person
            });
        }

        public CreateMemberViewModel Get(Guid Id)
        {
            var a = Get(m => m.Id.Equals(Id)).Include(m => m.Person);

            return a.AsEnumerable().Select(Result => new CreateMemberViewModel() { Member = Result }).FirstOrDefault();
        }

        public IEnumerable<Tree> Permission(Guid id, bool isDenied)
        {
            var member = uow.Get<MemberPermission>()
                            .AsQueryable()
                            .Where(m => id == m.MemberId)
                            .Where(m => m.IsDenied == isDenied)
                            .ToList();

            return uow.Get<Permission>().AsEnumerable().Select(Result => new Tree()
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

        public async Task<Response> Save(CreateMemberViewModel model)
        {
            Response result;

            try
            {
                if (model.Member.Id == null)
                {
                    Update(model.Member);

                    result = userService.Succeed(Alert.SuccessUpdate);
                }
                else
                {
                    Insert(model.Member);
                    result = userService.Succeed(Alert.SuccessInsert);
                }

                await uow.CommitAsync();
            }
            catch (Exception)
            {
                result = userService.Failed(Alert.ErrorInInsertOrUpdate);
            }

            return result;
        }

        public async Task<Response> Remove(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();

            uow.Set<Person>().Remove(
                uow.Get<Person>(m => m.Id.Equals(id)).First()
                );

            await uow.CommitAsync();

            return userService.Succeed(Alert.SuccessDelete);
        }
    }
}
