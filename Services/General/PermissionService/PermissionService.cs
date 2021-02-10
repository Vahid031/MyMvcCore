﻿using System;
using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using DatabaseContext;
using ViewModels.General.PermissionViewModel;
using Infrastructure.Entities;
using Services.GenericService;
using Services.UserService;
using Infrastructure.Common;
using System.Threading.Tasks;

namespace Services.General.PermissionService
{

    public class PermissionService : GenericService<Permission>, IPermissionService
    {
        public readonly IUserService userService;

        public PermissionService(IUnitOfWork uow, IUserService userService)
            : base(uow)
        {
            this.userService = userService;
        }

        public IEnumerable<ListPermissionViewModel> GetAll(ListPermissionViewModel list, ref Paging pg)
        {
            var query = uow.Set<Permission>()
                           .GroupJoin(uow.Set<Permission>(), x => x.ParentId, y => y.Id, (x, y) => new { Permission = x, Parent = y })
                           .SelectMany(x => x.Parent.DefaultIfEmpty(), (x, y) => new { x.Permission, Parent = y })
                           .Paging(list, ref pg);


            return query.AsEnumerable().Select(Result => new ListPermissionViewModel()
            {
                Permission = new Permission()
                {
                    Id = Result.Permission.Id,
                    Action = Result.Permission.Action,
                    Controller = Result.Permission.Controller,
                    Active = Result.Permission.Active,
                    Order = Result.Permission.Order,
                    ParentId = Result.Permission.ParentId,
                    Title = Result.Permission.Title,
                    Url = (string.IsNullOrEmpty(Result.Permission.Controller) ? "" : "../" + Result.Permission.Controller) + (string.IsNullOrEmpty(Result.Permission.Action) ? "" : "/" + Result.Permission.Action),
                    Parent = Result.Permission.Parent
                },
                Parent = Result.Parent
            });

        }

        public IEnumerable<Tree> Tree()
        {
            var query = uow.Get<Permission>().OrderBy(m => m.Order);

            return query.AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id,
                parentId = Result.ParentId,
                title = Result.Title,
                order = Result.Order,
                icon = Result.Icon,
                @checked = false,
                disabled = false
            });
        }

        public async Task ChangePeriority(Guid id, Guid parentId)
        {
            var permission = Find(id);

            var siblings = uow.Get<Permission>(m => m.ParentId.Equals(parentId)).OrderBy(m => m.Order).ToList();

            int i;
            for (i = 0; i < siblings.Count(); i++)
            {
                siblings[i].Order = i + 1;
            }

            permission.ParentId = parentId;
            permission.Order = i + 1;

            await uow.CommitAsync(userService.MemberId);
        }

        public async Task SetRolePermission(Guid roleId, Guid[] permissionId)
        {
            uow.Set<RolePermission>().RemoveRange(uow.Get<RolePermission>(m => m.RoleId == roleId));

            var list = new List<RolePermission>();

            foreach (var id in permissionId)
            {
                list.Add(new RolePermission()
                {
                    RoleId = roleId,
                    PermissionId = id
                });
            }
            uow.Set<RolePermission>().AddRange(list);

            await uow.CommitAsync(userService.MemberId);
        }

        public async Task SetMemberPermission(Guid _memberId, Guid[] permissionId, bool isDenied)
        {
            uow.Set<MemberPermission>().RemoveRange(
                uow.Get<MemberPermission>(m => m.MemberId == _memberId && (m.IsDenied == isDenied || permissionId.Contains(m.PermissionId.Value)))
                );

            var list = new List<MemberPermission>();

            foreach (var id in permissionId)
            {
                list.Add(new MemberPermission()
                {
                    MemberId = _memberId,
                    PermissionId = id,
                    IsDenied = isDenied
                });
            }
            uow.Set<MemberPermission>().AddRange(list);

            await uow.CommitAsync(userService.MemberId);
        }

        public async Task InsertAsync(CreatePermissionViewModel model)
        {
            model.Permission.Id = Guid.NewGuid();
            model.Permission.CreateDate = new DateTime();

            Insert(model.Permission);
            await uow.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, CreatePermissionViewModel model)
        {
            var permission = Find(id);

            if (permission == null)
                return;

            permission.Action = model.Permission.Action;
            permission.Controller = model.Permission.Controller;
            permission.Active = model.Permission.Active;
            permission.Visible = model.Permission.Visible;
            permission.Title = model.Permission.Title;
            permission.Icon = model.Permission.Icon;

            Update(permission);
            await uow.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();
            Delete(id);

            await uow.CommitAsync();
        }
    }
}

