using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Pages
{
    public class HandlerSelectorModel : PageModel
    {
        private DataContext _dataContext;

        public Product Product { get; set; }

        public HandlerSelectorModel(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task OnGetAsync(long id = 1)
        {
            Product = await _dataContext.Products.FindAsync(id);
        }

        public async Task OnGetRelatedAsync(long id = 1)
        {
            Product = await _dataContext.Products.Include(p => p.Supplier)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            Product.Supplier.Products = null;
            Product.Category.Products = null;
        }
        public async Task OnGetRelatedNewAsync(long id = 1)
        {
            Product = await _dataContext.Products.Include(p => p.Supplier)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            
            Product.Category = _dataContext.Categories.Find(long.Parse("3"));
            Product.Supplier = _dataContext.Suppliers.Find(long.Parse("3"));
            Product.Supplier.Products = null;
            Product.Category.Products = null;
        }
    }
}
