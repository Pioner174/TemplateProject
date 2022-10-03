using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Pages
{
    public class EditorModel : PageModel
    {
        private DataContext _dataContext;

        public Product Product { get; set; }

        public EditorModel(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            Product = await _dataContext.Products.FindAsync(id);
            if (Product == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();


        }

        public async Task<IActionResult> OnPostAsync(long id, decimal price)
        {
            Product p = await _dataContext.Products.FindAsync(id);
            p.Price = price;
            await _dataContext.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
