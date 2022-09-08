using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TemplateProject.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if(context.Products.Count() == 0
                && context.Suppliers.Count() == 0
                && context.Categories.Count() == 0) {
                
                Supplier s1 = new Supplier { Name = "Марья Ивановна", City = "Москва"};
                Supplier s2 = new Supplier { Name = "Пётр Кожухов", City = "Санкт-Петербург" };
                Supplier s3 = new Supplier { Name = "Анатолий Ильич", City = "Екатеринбург" };

                Category c1 = new Category { Name = "Продукты питания" };
                Category c2 = new Category { Name = "Спорт инвентарь" };
                Category c3 = new Category { Name = "Техника" };

                context.Products.AddRange(
                    new Product { Name = "Молоко", Price = 75, Category = c1, Supplier = s1 },
                    new Product { Name = "Хлеб", Price = 50, Category = c1, Supplier = s2 },
                    new Product { Name = "Колбаса", Price = 215, Category = c1, Supplier = s3 },
                    new Product { Name = "Мяч", Price = 750, Category = c2, Supplier = s1 },
                    new Product { Name = "Гантеля", Price = 1750, Category = c2, Supplier = s2 },
                    new Product { Name = "Сноуборд", Price = 7760, Category = c2, Supplier = s3 },
                    new Product { Name = "Дисплей", Price = 23400, Category = c3, Supplier = s3 },
                    new Product { Name = "Ноутбук", Price = 125990, Category = c3, Supplier = s2 },
                    new Product { Name = "Смартфон", Price = 45600, Category = c3, Supplier = s1 }
                    );

                context.SaveChanges();
            }
        }
    }
}
