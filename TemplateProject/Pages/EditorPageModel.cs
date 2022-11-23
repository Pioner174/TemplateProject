using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
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
    }
}
