using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Entities;
using Infrastructure.Validation;

namespace DomainModels.General
{
    [Table("Permissions", Schema = "General")]
    public class Permission : BaseEntity
    {
        [Necessary]
        [DefaultValue("")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "حد اکثر 25 کاراکتر")]
        [Display(Name = "عنوان دسترسی")]
        public string Title { get; set; }

        [DefaultValue("")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "حد اکثر 25 کاراکتر")]
        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [DefaultValue("")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "حد اکثر 25 کاراکتر")]
        [Display(Name = "Action")]
        public string Action { get; set; } = "";

        [NotMapped]
        [Display(Name = "مسیر")]
        public string Url { get; set; }

        [DefaultValue(99)]
        [Display(Name = "اولویت")]
        public int? Order { get; set; }

        [Display(Name = "فعال")]
        public bool? Active { get; set; }

        [Display(Name = "والد")]
        public Guid? ParentId { get; set; }

        [DefaultValue("")]
        [Display(Name = "Icon")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "حد اکثر 25 کاراکتر")]
        public string Icon { get; set; }

        [Display(Name = "قابل مشاهده")]
        public bool? Visible { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Permission Parent { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

    }
}
