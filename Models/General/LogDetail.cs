using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Entities;

namespace DomainModels.General
{
    [Table("LogDetails", Schema = "General")]
    public class LogDetail : BaseEntity
    {
        [Display(Name = "فیلد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        public string PropertyName { get; set; }
               
        [Display(Name = "نام")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر")]
        public string PropertyValue { get; set; }

        [Display(Name = "وقعه")]
        public Guid? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        public virtual Log Log { get; set; }
    }
}
