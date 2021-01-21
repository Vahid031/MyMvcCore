using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Validation;

namespace DomainModels.General
{
    [Table("LogDetails", Schema = "General")]
    public class LogDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Display(Name = "فیلد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        public string PropertyName { get; set; }
               
        [Display(Name = "نام")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر")]
        public string PropertyValue { get; set; }

        [Display(Name = "وقعه")]
        public int? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        public virtual Log Log { get; set; }
    }
}
