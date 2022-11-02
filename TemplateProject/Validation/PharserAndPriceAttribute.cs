using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using TemplateProject.Models;

namespace TemplateProject.Validation
{
    public class PharserAndPriceAttribute : ValidationAttribute
    {
        public string Phrase { get; set; }

        public string Price { get; set; }
         
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = value as Product;
            
            if(product != null &&
                product.Name.ToLower().StartsWith(Phrase.ToLower(), StringComparison.OrdinalIgnoreCase) &&
                product.Price > decimal.Parse(Price))
            {
                return new ValidationResult($"{Price} не верная цена для {Phrase} товара");
            }
            return ValidationResult.Success;
        }
    }
}
