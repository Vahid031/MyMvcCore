using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Roles", Schema = "General")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [StringLength(50, MinimumLength=1, ErrorMessage="حد اکثر 50 کاراکتر")]
        [Display(Name="عنوان نقش")]
        public string Title { get; set; }

        public virtual ICollection<RoleMember> RoleMembers { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        [Display(Name = "والد")]
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Role RoleParent { get; set; }


    }
}
