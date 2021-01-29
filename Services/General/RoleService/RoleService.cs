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
        private readonly IUserService userService;

        public RoleService(IUnitOfWork uow, IUserService userService)
            : base(uow)
        {
            this.userService = userService;
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

        public async Task<Response> Save(CreateRoleViewModel model)
        {
            Response result;

            try
            {
                if (model.Role.Id == null)
                {
                    Update(model.Role);
                    result = userService.Succeed("اطلاعات با موفقیت ویرایش شد");
                }
                else
                {
                    Insert(model.Role);
                    result = userService.Succeed("اطلاعات با موفقیت ثبت شد");
                }

                await uow.CommitAsync();
            }
            catch (Exception)
            {
                result = userService.Failed("مشکلی در درج اطلاعات به وجود آمده است");
            }

            return result;
        }

        public async Task<Response> Remove(Guid id)
        {
            Response result;

            try
            {
                //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();
                Delete(id);
                result = userService.Succeed("اطلاعات با موفقیت حذف شد");

                await uow.CommitAsync();
            }
            catch (Exception)
            {
                result = userService.Failed("مشکلی در درج اطلاعات به وجود آمده است");
            }

            return result;
        }
    }
}