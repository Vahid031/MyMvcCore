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

        Task<Response> ChangePeriority(Guid id, Guid parentId);

        Task<Response> SetRolePermission(Guid roleId, Guid[] permissionId);

        Task<Response> SetMemberPermission(Guid memberId, Guid[] permissionId, bool isDenied);

        Task<Response> Save(CreatePermissionViewModel model);

        Task<Response> Remove(Guid Id);
    }
}