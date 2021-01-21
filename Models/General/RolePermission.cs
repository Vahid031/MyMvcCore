using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("RolePermissions", Schema = "General")]
    public class RolePermission
    {
        [Key]
        public int? Id { get; set; }

        [DisplayName("شناسه نقش")]
        public int? RoleId { get; set; }

        [DisplayName("شناسه مجوز")]
        public int? PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
