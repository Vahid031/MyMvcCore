using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("BranchRoleMembers", Schema = "General")]
    public class BranchRoleMember : BaseEntity
    {
        public Guid? MemberId { get; set; }
        
        public Guid? BranchRoleId { get; set; }

        [ForeignKey(nameof(BranchRoleId))]
        public BranchRole BranchRole { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
