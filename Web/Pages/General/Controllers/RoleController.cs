using System.Linq;
using Infrastructure.Entities;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Services.General.RoleService;
using Services.UserService;
using ViewModels.General.RoleViewModel;

namespace Web.Pages.General.Controllers
{
    [Authorize("Vahid")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> logger;
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService, IUserService userService)
        {
            this.logger = logger;
            this.roleService = roleService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _Update(int id)
        {
            var model = new CreateRoleViewModel()
            {
                Role = roleService.Find(id),
                Parents = roleService.Get(m => m.Id != id).AsEnumerable().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Title })
            };

            return PartialView("_Create", model);
        }

        [HttpPost]
        public JsonResult _Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
                return Json(roleService.Save(model));
            else
                return Json(userService.Failed(Alert.ErrorInInputParameter));
        }

        [HttpPost]
        public JsonResult _List(ListRoleViewModel list, Paging pg)
        {
            return Json(userService.Result(roleService.GetAll(list, ref pg), pg));
        }

        [HttpPost]
        public JsonResult _Delete(int id)
        {
            return Json(roleService.Remove(id));
        }

        [HttpPost]
        public JsonResult _Tree()
        {
            return Json(roleService.Tree());
        }

        [HttpPost]
        public JsonResult _Permission(int id)
        {
            return Json(roleService.Permission(id));
        }

    }
}