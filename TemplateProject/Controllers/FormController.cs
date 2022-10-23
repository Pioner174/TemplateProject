using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private DataContext _dataContext;

        public FormController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name");

            return View("Form", await _dataContext.Products.Include(p => p.Category).Include(p => p.Supplier)
                .FirstAsync(p => p.ProductId == id));
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (string key in Request.Form.Keys)
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View(TempData);
        }
    }
}
