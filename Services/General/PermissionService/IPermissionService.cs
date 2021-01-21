using DomainModels.General;
using Infrastructure.Entities;
using Services.GenericService;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General.PermissionViewModel;

namespace Services.General.PermissionService
{
    public interface IPermissionService : IGenericService<Permission>
    {
        IEnumerable<ListPermissionViewModel> GetAll(ListPermissionViewModel list, ref Paging pg);

        IEnumerable<Tree> Tree();

        Task<Response> ChangePeriority(int id, int parentId);

        Task<Response> SetRolePermission(int roleId, int[] permissionId);

        Task<Response> SetMemberPermission(int memberId, int[] permissionId, bool isDenied);

        Task<Response> Save(CreatePermissionViewModel model);

        Task<Response> Remove(int Id);
    }
}