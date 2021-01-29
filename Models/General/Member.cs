using Infrastructure.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.General
{
    [Table("Members", Schema = "General")]
    public class Member : BaseEntity
    {
        [StringLength(25, MinimumLength = 1, ErrorMessage = "حد اکثر 25 کاراکتر")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [DefaultValue("")]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "حد اکثر 64 کاراکتر")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "تکرار رمز عبور")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "حد اکثر 64 کاراکتر")]
        [Compare(nameof(Password), ErrorMessage = "مقادیر یکسان نیست")]
        [DataType(DataType.Password)]
        public string PasswordCampare { get; set; }

        [Display(Name = "فعال")]
        public bool? Active { get; set; }

        public Guid? PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}
