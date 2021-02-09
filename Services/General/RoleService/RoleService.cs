using System;
using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using DatabaseContext;
using ViewModels.General.RoleViewModel;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Services.GenericService;
using Services.UserService;
using Infrastructure.Common;
using System.Threading.Tasks;

namespace Services.General.RoleService
{

    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<ListRoleViewModel> GetAll(ListRoleViewModel list, ref Paging pg)
        {
            return Get().Paging(list, ref pg).AsEnumerable().Select(Result => new ListRoleViewModel()
            {
                Role = Result
            });
        }

        public IEnumerable<Tree> Tree()
        {
            return Get().AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id.Value,
                parentId = Result.ParentId,
                @checked = false,
                disabled = false,
                icon = "",
                order = 0,
                title = Result.Title
            });
        }

        public IEnumerable<Tree> Permission(Guid id)
        {

            var role = uow.Set<RolePermission>().AsQueryable().Where(m => id.Equals(m.RoleId)).ToList();


            return uow.Set<Permission>().AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id.Value,
                parentId = Result.ParentId,
                @checked = role.Any(m => m.PermissionId == Result.Id),
                disabled = false,
                icon = Result.Icon,
                order = Result.Order,
                title = Result.Title
            });
        }

        public async Task Save(CreateRoleViewModel model)
        {
            if (model.Role.Id == null)
                Update(model.Role);
            else
                Insert(model.Role);

            await uow.CommitAsync();
        }

        public async Task Remove(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();
            Delete(id);

            await uow.CommitAsync();
        }
    }
}