using DomainModels.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? Id { get; set; }

        [Index(IsUnique = true, IsClustered = true)]
        [Display(Name = "تاریخ ایجاد")]
        public DateTime? CreateDate { get; set; }
    }
}
