using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Product : IEntity
    {
        [Display(Name = "کد محصول"), Required]
        public Guid? ProductID { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "دسته بندی"), Required]
        public Guid? CategoryID { get; set; }

        [Display(Name = "مقدار در واحد"), Required]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "قیمت واحد"), Required]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "موجودی واحد"), Required]
        public short? UnitsInStock { get; set; }

        public Category category { get; set; }
    }
}
