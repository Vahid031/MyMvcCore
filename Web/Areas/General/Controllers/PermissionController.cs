﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.General.PermissionService;
using Services.General.MemberService;
using System.Collections.Generic;
using System.Linq;
using ViewModels.General.PermissionViewModel;
using Microsoft.AspNetCore.Authorization;
using Services.UserService;
using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Common;
using System.Threading.Tasks;
using System;

namespace Web.Pages.General.Controllers
{
    [Authorize("Vahid")]
    public class PermissionController : Controller
    {
        private readonly ILogger<PermissionController> logger;
        private readonly IPermissionService permissionService;
        private readonly IMemberService memberService;
        private readonly IUserService userService;

        public PermissionController(ILogger<PermissionController> logger,
                                    IPermissionService permissionService,
                                    IMemberService memberService,
                                    IUserService userService)
        {
            this.logger = logger;
            this.permissionService = permissionService;
            this.memberService = memberService;
            this.userService = userService;
        }

        #region Views

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _Create()
        {
            return PartialView();
        }

        public IActionResult _Order()
        {
            return PartialView();
        }

        public IActionResult _Role()
        {
            return PartialView();
        }

        public IActionResult _Member()
        {
            var list = new List<SelectListItem>();

            foreach (var member in memberService.Get().Include(m => m.Person).AsEnumerable())
            {
                list.Add(new SelectListItem() { Text = member.Person.FirstName + " " + member.Person.LastName, Value = member.Id.ToString() });
            }

            ViewBag.Members = list;

            return PartialView();
        }

        [HttpPost]
        public IActionResult _Update(Guid id)
        {
            var model = new CreatePermissionViewModel()
            {
                Permission = permissionService.Get().Include(m => m.Parent).Where(m => m.Id == id).FirstOrDefault()
            };

            return PartialView("_Create", model);
        }

        #endregion

        #region Methods
        [HttpPost]
        public IActionResult _Create(CreatePermissionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(Alert.ErrorInInputParameter.GetMessage());

            permissionService.Save(model);
            return Ok();
        }

        [HttpPost]
        public IActionResult _List(ListPermissionViewModel list, Paging pg)
        {
            return Json(new { Values = permissionService.GetAll(list, ref pg), Paging = pg });
        }

        public JsonResult _Tree()
        {
            return Json(permissionService.Tree());
        }

        public async Task<JsonResult> _Menu()
        {
            return Json(await userService.GetByMemberId());
        }

        [HttpPost]
        public JsonResult _Delete(Guid id)
        {
            return Json(permissionService.Remove(id));
        }

        [HttpPost]
        public JsonResult ChangePeriority(Guid id, Guid parentId)
        {
            return Json(permissionService.ChangePeriority(id, parentId));
        }

        [HttpPost]
        public JsonResult SetRolePermission(Guid roleId, Guid[] permissionId)
        {
            return Json(permissionService.SetRolePermission(roleId, permissionId));
        }

        [HttpPost]
        public JsonResult SetMemberPermission(Guid memberId, Guid[] permissionId, bool isDenied)
        {
            return Json(permissionService.SetMemberPermission(memberId, permissionId, isDenied));
        }

        #endregion
    }
}