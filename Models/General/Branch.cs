using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Branchs", Schema = "General")]
    public class Branch : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }

        public int? Type { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Branch Parent { get; set; }

        public ICollection<BranchRole> BranchRoles { get; set; }
    }
}
