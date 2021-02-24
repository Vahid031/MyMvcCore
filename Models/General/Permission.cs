using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Permissions", Schema = "General")]
    public class Permission : BaseEntity
    {
        [StringLength(25)]
        public string Title { get; set; }

        [StringLength(25)]
        public string Controller { get; set; }

        [StringLength(25)]
        public string Action { get; set; }

        public int? Order { get; set; }

        public bool? Active { get; set; }

        public Guid? ParentId { get; set; }

        [StringLength(25)]
        public string Icon { get; set; }

        public bool? Visible { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Permission Parent { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

    }
}
