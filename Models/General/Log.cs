using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DomainModels.General
{
    [Table("Logs", Schema = "General")]
    public class Log : BaseEntity
    {
        [MaxLength(50)]
        public string TableName { get; set; }

        public Guid? RowId { get; set; }

        [MaxLength(10)]
        public byte? State { get; set; }

        public DateTime? Date { get; set; }

        public Guid? MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public  Member Member { get; set; }

        public ICollection<LogDetail> LogDetails { get; set; }
    }
}
