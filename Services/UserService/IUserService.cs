using DomainModels.General;
using Infrastructure.Entities;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General;

namespace Services.UserService
{
    public interface IUserService
    {
        Guid MemberId { get; }

        bool IsAuthenticated { get; }

        Task<bool> HasPermission(string controller, string action);

        Task LogoutAsync();

        Task<bool> LoginAsync(LoginViewModel loginViewModel);

        Task<IEnumerable<Permission>> GetByMemberId();

        //Response<TEntity> Result<TEntity>(TEntity data, Paging pg = null, string message = "", AlertType type = AlertType.success);

        ////Response<TEntity> Result<TEntity>(TEntity data, Paging pg = null, Alert? alert = null, AlertType type = AlertType.success);

        //Response Succeed(string message, AlertType type = AlertType.success);

        //Response Succeed(Alert? alert = null, AlertType type = AlertType.success);

        //Response Failed(string message, AlertType type = AlertType.danger);

        //Response Failed(Alert? alert = null, AlertType type = AlertType.danger);
    }
}
