﻿using Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? Id { get; set; }

        [Index(IsUnique = true, IsClustered = true)]
        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm}")]
        public DateTime? CreateDate { get; set; }


        //public static bool operator ==(Guid a, Guid b) => a.ToString().Equals(b.ToString());
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}