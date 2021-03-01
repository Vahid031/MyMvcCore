using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.General
{
    [Table("LogDetails", Schema = "General")]
    public class LogDetail : BaseEntity
    {
        [MaxLength(50)]
        public string Key { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }

        public Guid? LogId { get; set; }

        [ForeignKey(nameof(LogId))]
        public virtual Log Log { get; set; }
    }
}
