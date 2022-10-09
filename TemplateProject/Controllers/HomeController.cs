using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.AveragePrice = await _dataContext.Products.AverageAsync(p => p.Price);
            ViewBag.StringData = "sdsd";
            Product p =  await _dataContext.Products.FindAsync(id);

            return View(p);
        }


        public async Task<IActionResult> Products(long id = 1)
        {
            Product p = await _dataContext.Products.FindAsync(id);

            return View(p);
        }
        public IActionResult Common()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(_dataContext.Products);
        }
    }
}
