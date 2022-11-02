using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateProject.Models
{
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


        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
