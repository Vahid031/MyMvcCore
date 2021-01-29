using Infrastructure.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("RoleMembers", Schema = "General")]
    public class RoleMember : BaseEntity
    {
        public Guid? MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        public Guid? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }


    }
}
