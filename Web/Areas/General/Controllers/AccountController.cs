using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ViewModels.General;
using Microsoft.AspNetCore.Authorization;
using Services;

namespace Web.Pages.General.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IUserService userService;

        public AccountController(//IUserService userService
            )
        {
            //this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            //if (userService.IsAuthenticated)
            //    return Redirect("/");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            string returnUrl = ViewBag.ReturnUrl;

            //if (await userService.LoginAsync(loginViewModel))
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
            return Json(true);
            //return Json(userService.IsAuthenticated);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //await userService.LogoutAsync();
            return Redirect("/");
        }

    }
}
