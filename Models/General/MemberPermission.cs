using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("MemberPermissions", Schema = "General")]
    public class MemberPermission
    {
        [Key]
        public int? Id { get; set; }

        [DisplayName("شناسه کاربر")]
        public int? MemberId { get; set; }

        [DisplayName("شناسه مجوز")]
        public int? PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        [Display(Name ="منع دسترسی")]
        public bool? IsDenied { get; set; }
    }
}
