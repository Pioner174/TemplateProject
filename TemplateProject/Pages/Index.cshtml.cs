using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TemplateProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace TemplateProject.Pages
{
    public class IndexModel : PageModel
    {
        private DataContext _context;

        public Product Product { get; set; }

        public IndexModel(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IActionResult> OnGetAsync(long id = 1)
        {
            
            Product = await _context.Products.FindAsync(id);
            if(Product == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
            
            
            
        }
    }
}
