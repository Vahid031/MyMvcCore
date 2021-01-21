using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DomainModels.General
{
    [Table("Logs", Schema = "General")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Display(Name = "نام جدول")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        public string TableName { get; set; }

        [Display(Name = "شناسه سطر")]
        public int? RowId { get; set; }

        [Display(Name = "نوع عملیات")]
        [StringLength(10, ErrorMessage = "حداکثر 10 کاراکتر")]
        public byte? State { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm}")]
        public DateTime? Date { get; set; }

        [Display(Name = "کاربر ثبت کننده")]
        public int? MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        public ICollection<LogDetail> LogDetails { get; set; }
    }
}
