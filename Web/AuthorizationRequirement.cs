using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Services;
using System.Threading.Tasks;

namespace Web
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public AuthorizationRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }

        public AuthorizationRequirement()
        {
            PermissionName = "Vahid";
        }
        public string PermissionName { get; private set; }
    }

    public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        private readonly IUserService userService;

        public PermissionHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            if (context.Resource is RouteEndpoint endpoint)
            {
                endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);
                endpoint.RoutePattern.RequiredValues.TryGetValue("action", out var _action);

                endpoint.RoutePattern.RequiredValues.TryGetValue("page", out var _page);
                endpoint.RoutePattern.RequiredValues.TryGetValue("area", out var _area);

                if (context.User.Identity.IsAuthenticated && _controller != null && _action != null &&
                       await userService.HasPermission(_controller.ToString(), _action.ToString()))
                {
                    context.Succeed(requirement);
                }
            }

            await Task.CompletedTask;
        }
    }
}
