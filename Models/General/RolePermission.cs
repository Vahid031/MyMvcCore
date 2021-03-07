using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("RolePermissions", Schema = "General")]
    public class RolePermission : BaseEntity
    {
        public Guid? PermissionId { get; set; }

        public Guid? RoleId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
