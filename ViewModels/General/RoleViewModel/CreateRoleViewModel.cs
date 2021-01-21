using DomainModels.General;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ViewModels.General.RoleViewModel
{
    public class CreateRoleViewModel
    {
        public Role Role { get; set; }
        public IEnumerable<SelectListItem> Parents { get; set; }
    }
}
