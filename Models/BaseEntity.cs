using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }

        [Index(IsUnique = true, IsClustered = true)]
        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm}")]
        public DateTime? CreateDate { get; set; }


        //public static bool operator ==(Guid a, Guid b) => a.ToString().Equals(b.ToString());
        public BaseEntity()
        {
            if (Id == null)
                Id = new Guid();
        }
    }
}
