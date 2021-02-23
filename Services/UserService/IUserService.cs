using DomainModels.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.General;

namespace Services
{
    public interface IUserService
    {
        Guid MemberId { get; }

        bool IsAuthenticated { get; }

        Task<bool> HasPermission(string controller, string action);

        Task LogoutAsync();

        Task<bool> LoginAsync(LoginViewModel loginViewModel);

        Task<IEnumerable<Permission>> GetByMemberId();
    }
}
