﻿using System;
using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using DatabaseContext;
using ViewModels.General.RoleViewModel;
using ViewModels.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using ViewModels.Common;
using System.Threading.Tasks;
using Repository;
using Repository.General;

namespace Services.General.RoleService
{

    public class RoleService :  IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;
        private readonly IPermissionRepository permissionRepository;

        public RoleService(IUnitOfWork unitOfWork, 
                           IRoleRepository roleRepository,
                           IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
            this.permissionRepository = permissionRepository;
        }

        public IEnumerable<ListRoleViewModel> GetAll(ListRoleViewModel list, ref Paging pg)
        {
            return roleRepository.Get().Paging(list, ref pg).AsEnumerable().Select(Result => new ListRoleViewModel()
            {
                Role = Result
            });
        }

        public IEnumerable<Tree> Tree()
        {
            return roleRepository.Get().AsEnumerable().Select(Result => new Tree()
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

            //var role = uow.Set<RolePermission>().AsQueryable().Where(m => id.Equals(m.RoleId)).ToList();


            return permissionRepository.Get().AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id.Value,
                parentId = Result.ParentId,
                @checked = true,//role.Any(m => m.PermissionId == Result.Id),
                disabled = false,
                icon = Result.Icon,
                order = Result.Order,
                title = Result.Title
            });
        }

        public async Task Save(CreateRoleViewModel model)
        {
            //if (model.Role.Id == null)
            //    Update(model.Role);
            //else
            //    Insert(model.Role);

            await unitOfWork.CommitAsync();
        }

        public async Task Remove(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();
            //Delete<Role>(id);

            await unitOfWork.CommitAsync();
        }
    }
}