using System.Linq;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using DatabaseContext;
using DomainModels.General;
using ViewModels.General;
using Infrastructure.Entities;
using Infrastructure.Enums;
using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpContext context;
        private readonly IUnitOfWork uow;
        private readonly IMemoryCache memoryCache;

        public UserService(IHttpContextAccessor context, IUnitOfWork uow, IMemoryCache memoryCache)
        {
            this.context = context.HttpContext;
            this.uow = uow;
            this.memoryCache = memoryCache;
        }
        public Guid MemberId
        {
            get
            {
                var guid = context.User.Claims.First(m => m.Type.Equals(ClaimTypes.NameIdentifier)).Value;
                return new Guid(guid);
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return context.User.Identity.IsAuthenticated;
            }
        }

        public async Task<bool> HasPermission(string controller, string action)
        {
            return (await GetByMemberId()).Any(m => m.Controller.Equals(controller.ToLower()) && m.Action.Equals(action.ToLower()));
        }

        public async Task LogoutAsync()
        {
            await context.SignOutAsync();
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var member = uow.Get<Member>(m => m.UserName.Equals(loginViewModel.UserName.ToLower())).FirstOrDefault();

            if (member == null)
                return false;

            if (!member.Password.Equals(Hashing.MultiEncrypt(loginViewModel.Password)))
                return false;

            var user = new User()
            {
                UserName = loginViewModel.UserName,
                PasswordHash = Hashing.MultiEncrypt(loginViewModel.Password),
                Id = member.Id.ToString()

            };

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginViewModel.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.NameIdentifier,member.Id.ToString())
                };

            //foreach (var permission in await GetUserPermission())
            //{
            //    claims.Add(new Claim("permission", permission.Controller.ToLower() + "/" + permission.Action.ToLower()));
            //}
            //Task.WaitAll();

            await context.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", ClaimTypes.Name, ClaimTypes.Role)));

            return true;
        }

        public async Task<IEnumerable<Permission>> GetByMemberId()
        {
            var all = uow.Set<RolePermission>()
                     .Join(uow.Set<RoleMember>(), x => x.RoleId, y => y.RoleId, (x, y) => new { x.PermissionId, y.MemberId });

            var denied = uow.Set<MemberPermission>().Where(m => m.IsDenied ?? false).Select(m => new { m.PermissionId, m.MemberId });

            var access = uow.Set<MemberPermission>().Where(m => !(m.IsDenied ?? false)).Select(m => new { m.PermissionId, m.MemberId });


            var query = all.Union(access).Except(denied).Where(m => m.MemberId == MemberId)
                     .Join(uow.Get<Permission>(), x => x.PermissionId, y => y.Id, (x, y) => new { y.Icon, y.Visible, y.Controller, y.Action, y.Id, y.Title, y.Order, y.ParentId, y.Active })
                     .Where(m => m.Active.Value)
                     .OrderBy(m => m.Order);

            var permissions = await memoryCache.GetOrCreateAsync("Permissions", async x => await (query).ToListAsync());

            return permissions.AsEnumerable().Select(Result => new Permission()
            {
                Id = Result.Id,
                ParentId = Result.ParentId,
                Title = Result.Title,
                Order = Result.Order,
                Icon = Result.Icon,
                Controller = Result.Controller.ToLower(),
                Action = Result.Action.ToLower(),
                Visible = Result.Visible,
                Url = (string.IsNullOrEmpty(Result.Controller) ? "" : "../" + Result.Controller) + (string.IsNullOrEmpty(Result.Action) ? "" : "/" + Result.Action)
            });
        }

        public Response<TEntity> Result<TEntity>(TEntity data, Paging pg = null, string message = "", AlertType type = AlertType.success)
        {
            return new Response<TEntity>()
            {
                Success = true,
                Message = message,
                Type = type.ToString(),
                Data = data,
                Paging = pg
            };
        }

        public Response<TEntity> Result<TEntity>(TEntity data, Paging pg = null, Alert? alert = null, AlertType type = AlertType.success)
        {
            return new Response<TEntity>()
            {
                Success = true,
                Message = alert?.GetMessage(),
                Type = type.ToString(),
                Data = data,
                Paging = pg
            };
        }

        public Response Succeed(string message, AlertType type = AlertType.success)
        {
            return new Response()
            {
                Success = true,
                Message = message,
                Type = type.ToString()
            };
        }

        public Response Succeed(Alert? alert = null, AlertType type = AlertType.success)
        {
            return new Response()
            {
                Success = true,
                Message = alert?.GetMessage(),
                Type = type.ToString()
            };
        }

        public Response Failed(string message, AlertType type = AlertType.danger)
        {
            return new Response()
            {
                Success = false,
                Message = message,
                Type = type.ToString(),
                Errors = new List<string>() { message }
            };
        }

        public Response Failed(Alert? alert = null, AlertType type = AlertType.danger)
        {
            return new Response()
            {
                Success = false,
                Message = alert?.GetMessage(),
                Type = type.ToString(),
                Errors = new List<string>() { alert?.GetMessage() }
            };
        }
    }
}