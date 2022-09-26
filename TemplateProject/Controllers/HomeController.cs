using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            Product p =  await _dataContext.Products.FindAsync(id);

            if(p.CategoryId == 1)
            {
                return View("Products", p);
            }
            return View(p);
        }

        public IActionResult Common()
        {
            return View();
        }
    }
}
