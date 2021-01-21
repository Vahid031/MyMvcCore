using DomainModels.General;
using Infrastructure.Entities;
using Services.GenericService;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General.RoleViewModel;

namespace Services.General.RoleService
{
    public interface IRoleService : IGenericService<Role>
    {
        IEnumerable<ListRoleViewModel> GetAll(ListRoleViewModel list, ref Paging pg);

        IEnumerable<Tree> Tree();

        IEnumerable<Tree> Permission(int id);

        Task<Response> Save(CreateRoleViewModel model);

        Task<Response> Remove(int id);
    }
}