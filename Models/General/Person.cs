using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Validation;

namespace DomainModels.General
{
    [Table("Persons", Schema = "General")]
    public class Person : BaseEntity
    {
        [Display(Name = "نام")]
        [StringLength(25, ErrorMessage = "حداکثر 25 کاراکتر")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [StringLength(25, ErrorMessage = "حداکثر 25 کاراکتر")]
        public string LastName { get; set; }

        [Display(Name = "جنسیت")]
        public bool? Gender { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10)]
        [IranianNationalCode(ErrorMessage = "کد ملی معتبر نیست")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [StringLength(11)]
        public string MobileNumber { get; set; }

        [Display(Name = "شماره ثابت")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "تاریخ تولد")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل صحیح نیست")]
        public string Email { get; set; }
    }
}
