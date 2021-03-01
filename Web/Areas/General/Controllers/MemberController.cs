using ViewModels.Entities;
using ViewModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.General.MemberService;
using System;
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

        #region Views

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult _Create()
        {
            return PartialView(new CreateMemberViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> _Create(CreateMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(Alert.ErrorInInputParameter.GetMessage());
            if (model.Member.Id != null)
                await memberService.InsertAsync(model);
            return Ok(Alert.SuccessInsert.GetMessage());
        }

        [HttpPost]
        public IActionResult _Update(Guid id)
        {
            return PartialView(nameof(_Create), memberService.Get(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> _Update(Guid id, CreateMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(Alert.ErrorInInputParameter.GetMessage());

            await memberService.UpdateAsync(id, model);
            return Ok();
        }

        #endregion

        #region Methods

        [HttpPost]
        public IActionResult _List(ListMemberViewModel list, Paging pg)
        {
            return Json(new { Values = memberService.GetAll(list, ref pg), Paging = pg });
        }

        [HttpPost]
        public async Task<IActionResult> _Delete(Guid id)
        {
            await memberService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult _Permission(Guid id, bool isDenied)
        {
            return Json(new { Values = memberService.Permission(id, isDenied) });
        }
        #endregion

        //[HttpPost]
        //public async Task<IActionResult> _Upload(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot",
        //                file.FileName);

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return RedirectToAction("Files");
        //}

        //public async Task<IActionResult> Download(string filename)
        //{
        //    if (filename == null)
        //        return Content("filename not present");

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);

        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, GetContentType(path), Path.GetFileName(path));
        //}

        //private string GetContentType(string path)
        //{
        //    var types = GetMimeTypes();
        //    var ext = Path.GetExtension(path).ToLowerInvariant();
        //    return types[ext];
        //}

        //private Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".txt", "text/plain"},
        //        {".pdf", "application/pdf"},
        //        {".doc", "application/vnd.ms-word"},
        //        {".docx", "application/vnd.ms-word"},
        //        {".xls", "application/vnd.ms-excel"},
        //        {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"},
        //        {".csv", "text/csv"}
        //    };
        //}
    }
}
