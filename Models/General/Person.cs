using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.General
{
    [Table("Persons", Schema = "General")]
    public class Person : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public bool? Gender { get; set; }

        [MaxLength(10)]
        public string NationalCode { get; set; }

        [MaxLength(11)]
        public string MobileNumber { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public string Email { get; set; }
    }
}
