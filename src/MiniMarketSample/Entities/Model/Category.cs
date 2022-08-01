﻿using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Category: IEntity
    {
        [Display(Name = "شناسه دسته"), Required]
        public Guid CategoryID { get; set; }

        [Display(Name = "نام دسته"), Required]
        public string CategoryName { get; set; }

        [Display(Name = "شرح"), Required]
        public string Description { get; set; }

        [Display(Name = "تصویر"), Required]
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
