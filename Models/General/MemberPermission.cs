using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("MemberPermissions", Schema = "General")]
    public class MemberPermission : BaseEntity
    {
        public Guid? MemberId { get; set; }

        public Guid? PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

        public bool? IsDenied { get; set; }
    }
}
