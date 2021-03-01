using System;
using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using ViewModels.General.PermissionViewModel;
using ViewModels.Entities;
using ViewModels.Common;
using System.Threading.Tasks;
using Repository;
using Repository.General;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace Services.General.PermissionService
{

    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMemberRepository memberRepository;
        private readonly IPermissionRepository permissionRepository;

        public PermissionService(IUnitOfWork unitOfWork,
                                 IMemberRepository memberRepository,
                                 IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.memberRepository = memberRepository;
            this.permissionRepository = permissionRepository;
        }

        public IEnumerable<ListPermissionViewModel> GetAll(ListPermissionViewModel list, ref Paging pg)
        {
            var query = permissionRepository.Get().Include(m => m.Parent).Paging(list, ref pg);

            return query.AsEnumerable().Select(Result => new ListPermissionViewModel()
            {
                Permission = new Permission()
                {
                    Id = Result.Id,
                    Action = Result.Action,
                    Controller = Result.Controller,
                    Active = Result.Active,
                    Order = Result.Order,
                    ParentId = Result.ParentId,
                    Title = Result.Title,
                    //Url = (string.IsNullOrEmpty(Result.Controller) ? "" : "../" + Result.Controller) + (string.IsNullOrEmpty(Result.Action) ? "" : "/" + Result.Permission.Action),
                    Parent = Result.Parent
                },
                Parent = Result.Parent
            });

        }

        public IEnumerable<Tree> Tree()
        {
            var query = permissionRepository.Get().OrderBy(m => m.Order);

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
            var permission = permissionRepository.Find(id);

            var siblings = permissionRepository.Get(m => m.ParentId.Equals(parentId)).OrderBy(m => m.Order).ToList();

            int i;
            for (i = 0; i < siblings.Count(); i++)
            {
                siblings[i].Order = i + 1;
            }

            permission.ParentId = parentId;
            permission.Order = i + 1;

            await unitOfWork.CommitAsync();
        }

        public async Task SetRolePermission(Guid roleId, Guid[] permissionId)
        {
            //uow.Set<RolePermission>().RemoveRange(Get<RolePermission>(m => m.RoleId == roleId));

            //var list = new List<RolePermission>();

            //foreach (var id in permissionId)
            //{
            //    list.Add(new RolePermission()
            //    {
            //        RoleId = roleId,
            //        PermissionId = id
            //    });
            //}
            //uow.Set<RolePermission>().AddRange(list);

            await unitOfWork.CommitAsync();
        }

        public async Task SetMemberPermission(Guid _memberId, Guid[] permissionId, bool isDenied)
        {
            //uow.Set<MemberPermission>().RemoveRange(
            //    Get<MemberPermission>(m => m.MemberId == _memberId && (m.IsDenied == isDenied || permissionId.Contains(m.PermissionId.Value)))
            //);

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
            //uow.Set<MemberPermission>().AddRange(list);

            await unitOfWork.CommitAsync();
        }

        public async Task InsertAsync(CreatePermissionViewModel model)
        {
            model.Permission.Id = Guid.NewGuid();
            model.Permission.CreateDate = new DateTime();

            permissionRepository.Insert(model.Permission);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, CreatePermissionViewModel model)
        {
            var permission = permissionRepository.Find(id);

            if (permission == null)
                return;

            permission.Action = model.Permission.Action;
            permission.Controller = model.Permission.Controller;
            permission.Active = model.Permission.Active;
            permission.Visible = model.Permission.Visible;
            permission.Title = model.Permission.Title;
            permission.Icon = model.Permission.Icon;

            permissionRepository.Update(permission);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();
            permissionRepository.Delete(id);
            await unitOfWork.CommitAsync();
        }
    }
}

