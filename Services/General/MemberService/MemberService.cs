﻿using System.Linq;
using System.Collections.Generic;
using DomainModels.General;
using ViewModels.General.MemberViewModel;
using Infrastructure.Entities;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Repository.General;

namespace Services.General.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        private readonly IPermissionRepository permissionRepository;

        public MemberService(IMemberRepository memberRepository, IPermissionRepository permissionRepository)
        {
            this.memberRepository = memberRepository;
            this.permissionRepository = permissionRepository;
        }

        public IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg)
        {
            var query = memberRepository.Get().Include(m => m.Person).Paging(list, ref pg);

            return query.AsEnumerable().Select(Result => new ListMemberViewModel()
            {
                Member = Result,
                Person = Result.Person
            });
        }

        public CreateMemberViewModel Get(Guid Id)
        {
            var query = memberRepository.Get(m => m.PersonId == Id).Include(m => m.Person);


            return query.AsEnumerable().Select(Result => new CreateMemberViewModel()
            {
                Member = Result,
                Person = Result.Person
            }).FirstOrDefault();
        }

        public IEnumerable<Tree> Permission(Guid id, bool isDenied)
        {
            var memberPermission = Get<MemberPermission>()
                            .AsQueryable()
                            .Where(m => id == m.MemberId)
                            .Where(m => m.IsDenied == isDenied)
                            .ToList();

            return permissionRepository.Get().AsEnumerable().Select(Result => new Tree()
            {
                id = Result.Id,
                parentId = Result.ParentId,
                @checked = memberPermission.Any(m => m.PermissionId == Result.Id),
                disabled = false,
                icon = Result.Icon,
                order = Result.Order,
                title = Result.Title
            });
        }

        public async Task InsertAsync(CreateMemberViewModel model)
        {

            memberRepository.Insert(model.Member);
            await member.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, CreateMemberViewModel model)
        {

            memberRepository.Update(model.Member);
            await member.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();

            memberRepository.Delete(id);

            await member.CommitAsync();
        }
    }
}
