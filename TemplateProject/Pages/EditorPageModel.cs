using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Pages
{
    public class EditorPageModel : PageModel
    {
        public DataContext DataContext { get; set; }

        public ProductViewModel ViewModel { get; set; }

        public IEnumerable<Category> Categories => DataContext.Categories;

        public IEnumerable<Supplier> Suppliers => DataContext.Suppliers;

        public EditorPageModel(DataContext dbContext)
        {
            DataContext = dbContext;
        }
        
        protected async Task CheckNewCategory(Product product)
        {
            if(product.CategoryId == -1 && !string.IsNullOrEmpty(product.Category?.Name))
            {
                DataContext.Categories.Add(product.Category);
                await DataContext.SaveChangesAsync();

                product.CategoryId = product.Category.CategoryId;

                ModelState.Clear();
                TryValidateModel(product);
            }
        }
    }
}
