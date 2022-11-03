using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateProject.Validation;

namespace TemplateProject.Models
{
    [PharserAndPrice(Phrase = "Small", Price ="100")]
    public class Product
    {
        public long ProductId { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Column (TypeName ="decimal(8,2)")]
        //[DisplayFormat(DataFormatString="{0:c2}", ApplyFormatInEditMode =true)]
        //[BindNever]
        [Required(ErrorMessage ="Пожулуйста введите цену")]
        [Range(1, 999999, ErrorMessage ="Пожалуйста, укажите значение в диапозоне от 1 до 999999")]
        public decimal Price { get; set; }

        [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Category))]
        [Remote("CategoryKey", "Validation", ErrorMessage ="Введите существующий ключ")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Supplier))]
        [Remote("SupplierKey", "Validation", ErrorMessage = "Введите существующий ключ")]
        public long SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
