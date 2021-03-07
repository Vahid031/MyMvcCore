using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Members", Schema = "General")]
    public class Member : BaseEntity
    {
        [MaxLength(25)]
        public string UserName { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public bool? Active { get; set; }

        public Guid? PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }

        public ICollection<BranchRoleMember> BranchRoleMembers { get; set; }
    }
}
