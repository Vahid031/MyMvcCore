using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ViewModels.General;
using Services.General.MemberService;
using Services.General.PermissionService;
using Microsoft.AspNetCore.Authorization;
using Services.UserService;

namespace Web.Pages.General.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly IMemberService memberService;
        private readonly IPermissionService permissionService;
        private readonly IUserService userService;

        public AccountController(ILogger<AccountController> logger, 
                                 IMemberService memberService, 
                                 IPermissionService permissionService, 
                                 IUserService userService)
        {
            this.logger = logger;
            this.memberService = memberService;
            this.permissionService = permissionService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (userService.IsAuthenticated)
                return Redirect("/");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            string returnUrl = ViewBag.ReturnUrl;

            if (await userService.LoginAsync(loginViewModel))
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return Redirect("/");
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Content("AccessDenied!");
        }

        [HttpGet]
        public IActionResult CheckAuthentication()
        {
            return Json(userService.IsAuthenticated);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
            return Redirect("/");
        }

    }
}
