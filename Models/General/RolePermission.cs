using Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("RolePermissions", Schema = "General")]
    public class RolePermission : BaseEntity
    {
        [DisplayName("شناسه نقش")]
        public Guid? RoleId { get; set; }

        [DisplayName("شناسه مجوز")]
        public Guid? PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
