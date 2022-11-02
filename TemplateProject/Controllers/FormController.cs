using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<IActionResult> Index(long? id)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name");

            return View("Form", await _dataContext.Products.
                FirstOrDefaultAsync(p => id == null || p.ProductId == id));
        }

        [HttpPost]
        public IActionResult SubmitForm(Product product)
        {

            //if (string.IsNullOrEmpty(product.Name))
            //{
            //    ModelState.AddModelError(nameof(Product.Name), "Введите имя");
            //}

            //if (ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid && product.Price < 1)
            //{
            //    ModelState.AddModelError(nameof(Product.Price), "Введите положительную цену");
            //}
            
            if(ModelState.GetValidationState(nameof(Product.Name)) == ModelValidationState.Valid &&
                 ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid 
                && product.Name.ToLower().StartsWith("small") && product.Price > 100)
            {
                ModelState.AddModelError("", "Небольшие товары не могут стоить выше $100");
            }

            if(!_dataContext.Categories.Any(c=> c.CategoryId == product.CategoryId))
            {
                ModelState.AddModelError(nameof(Product.CategoryId), "Индентификатора не существует");
            }
            if(!_dataContext.Suppliers.Any(s=> s.SupplierId == product.SupplierId))
            {
                ModelState.AddModelError(nameof(Product.SupplierId), "Индентификатора не существует");
            }

            if (ModelState.IsValid)
            {
                TempData["name"] = product.Name;
                TempData["price"] = product.Price.ToString();
                TempData["categoryId"] = product.CategoryId.ToString();
                TempData["supplierId"] = product.SupplierId.ToString();
                return RedirectToAction(nameof(Results));
            }
            else
                return View("Form");
        }

        public IActionResult Results()
        {
            return View(TempData);
        }

    }
}
