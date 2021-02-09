using Infrastructure.Entities;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.General.MemberService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ViewModels.General.MemberViewModel;

namespace Web.Pages.General.Controllers
{
    [Authorize("Vahid")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> logger;
        private readonly IMemberService memberService;

        public MemberController(ILogger<MemberController> logger,
                                IMemberService memberService)
        {
            this.logger = logger;
            this.memberService = memberService;
        }

        [HttpGet]
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
        public IActionResult _Update(Guid id)
        {
            return PartialView(nameof(_Create), memberService.Get(id));
        }

        [HttpPost]
        public IActionResult _Create(CreateMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(Alert.ErrorInInputParameter.GetMessage());

            memberService.Save(model);
            return Ok();
        }

        [HttpPost]
        public IActionResult _List(ListMemberViewModel list, Paging pg)
        {
            return Json(new { Values = memberService.GetAll(list, ref pg), Paging = pg });
        }

        [HttpPost]
        public async Task<IActionResult> _Delete(Guid id)
        {
            await memberService.Remove(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult _Permission(Guid id, bool isDenied)
        {
            return Json(new { Values = memberService.Permission(id, isDenied) });
        }

        [HttpPost]
        public async Task<IActionResult> _Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
