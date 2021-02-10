using DomainModels.General;
using Infrastructure.Entities;
using Services.GenericService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General.PermissionViewModel;

namespace Services.General.PermissionService
{
    public interface IPermissionService : IGenericService<Permission>
    {
        IEnumerable<ListPermissionViewModel> GetAll(ListPermissionViewModel list, ref Paging pg);

        IEnumerable<Tree> Tree();

        Task ChangePeriority(Guid id, Guid parentId);

        Task SetRolePermission(Guid roleId, Guid[] permissionId);

        Task SetMemberPermission(Guid memberId, Guid[] permissionId, bool isDenied);

        Task InsertAsync(CreatePermissionViewModel model);

        Task UpdateAsync(Guid id, CreatePermissionViewModel model);

        Task DeleteAsync(Guid Id);
    }
}