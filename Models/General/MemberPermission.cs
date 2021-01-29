using Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("MemberPermissions", Schema = "General")]
    public class MemberPermission : BaseEntity
    {
        [DisplayName("شناسه کاربر")]
        public Guid? MemberId { get; set; }

        [DisplayName("شناسه مجوز")]
        public Guid? PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        [Display(Name ="منع دسترسی")]
        public bool? IsDenied { get; set; }
    }
}
