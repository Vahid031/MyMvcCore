using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Services;
using System.Reflection.Metadata;

namespace Web.Permission
{
    //[AttributeUsage(AttributeTargets.Class)]
    //public class Authorization : Attribute, IAuthorizationFilter
    //{
    //    private readonly IUserService userService;

    //    public Authorization(IUserService userService)
    //    {
    //        this.userService = userService;
    //    }

    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var controllerInfo = context.ActionDescriptor as ControllerActionDescriptor;
       
    //        if (!userService.IsAuthenticated)
    //        {
    //            context.Result = new ChallengeResult();
    //            return;
    //        }

    //        if (!userService.HasPermission(controllerInfo.ControllerName, controllerInfo.ActionName))
    //        {
    //            context.Result = new ForbidResult();
    //            return;
    //        }
    //    }
    //}

    

    //public class CustomError
    //{
    //    public string Error { get; }

    //    public CustomError(string message)
    //    {
    //        Error = message;
    //    }
    //}

    //public class CustomUnauthorizedResult : JsonResult
    //{
    //    public CustomUnauthorizedResult(string message, int statusCode) : base(new CustomError(message))
    //    {
    //        StatusCode = statusCode;
    //    }
    //}
    ////public class PermissionHandler : IAuthorizationHandler
    ////{
    ////    public Task HandleAsync(AuthorizationHandlerContext context)
    ////    {
    ////        var pendingRequirements = context.PendingRequirements.ToList();

    ////        foreach (var requirement in pendingRequirements)
    ////        {
    ////            if (requirement is ReadPermission)
    ////            {
    ////                if (IsOwner(context.User, context.Resource) ||
    ////                    IsSponsor(context.User, context.Resource))
    ////                {
    ////                    context.Succeed(requirement);
    ////                }
    ////            }
    ////            else if (requirement is EditPermission ||
    ////                     requirement is DeletePermission)
    ////            {
    ////                if (IsOwner(context.User, context.Resource))
    ////                {
    ////                    context.Succeed(requirement);
    ////                }
    ////            }
    ////        }

    ////        //TODO: Use the following if targeting a version of
    ////        //.NET Framework older than 4.6:
    ////        //      return Task.FromResult(0);
    ////        return Task.CompletedTask;
    ////    }

    ////    private bool IsOwner(ClaimsPrincipal user, object resource)
    ////    {
    ////        // Code omitted for brevity

    ////        return true;
    ////    }

    ////    private bool IsSponsor(ClaimsPrincipal user, object resource)
    ////    {
    ////        // Code omitted for brevity

    ////        return true;
    ////    }
    ////}

    //public class AccessToUrlRequirement : IAuthorizationRequirement
    //{
    //    public AccessToUrlRequirement(string url)
    //    {
    //        Url = url;
    //    }

    //    public string Url { get; private set; }
    //}

    //public class AccessToUrl : AuthorizationHandler<AccessToUrlRequirement>
    //{
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
    //                                                   AccessToUrlRequirement requirement)
    //    {
    //        if (context.User.HasClaim(c => c.Type == "BadgeId" &&
    //                                       c.Issuer == "http://microsoftsecurity"))
    //        {
    //            context.Succeed(requirement);
    //        }
    //        else
    //        {
    //            context.Fail();
    //        }
    //        return Task.CompletedTask;
    //    }
    //}


    //public class EditRequirement : IAuthorizationRequirement
    //{

    //}

    //public class Document
    //{
    //    public int Id { get; set; }
    //    public string Author { get; set; }
    //}

    //public class DocumentEditHandler : AuthorizationHandler<EditRequirement, Document>
    //{
    //    private readonly IUserService userService;

    //    public DocumentEditHandler(IUserService userService)
    //    {
    //        this.userService = userService;
    //    }
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EditRequirement requirement, Document resource)
    //    {
    //        if (resource.Author == context.User.FindFirst("").Value)
    //        {
    //            context.Succeed(requirement);
    //        }

    //        return Task.CompletedTask;
    //    }
    //}
}
