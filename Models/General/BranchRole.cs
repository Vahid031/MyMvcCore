using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("BranchRoles", Schema = "General")]
    public class BranchRole : BaseEntity
    {
        public Guid? BranchId { get; set; }
        
        public Guid? RoleId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
