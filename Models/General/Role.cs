using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Roles", Schema = "General")]
    public class Role : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Role Parent { get; set; }
    }
}
