using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TemplateProject.Models;

namespace TemplateProject.Pages
{
    public class NotFoundModel : PageModel
    {
        private DataContext _dataContext;

        public IEnumerable<Product> Products { get; set; }

        public NotFoundModel(DataContext ctx)
        {
            _dataContext = ctx;
        }
        public void OnGet(long id = 1)
        {
            Products = _dataContext.Products;
        }
    }
}
