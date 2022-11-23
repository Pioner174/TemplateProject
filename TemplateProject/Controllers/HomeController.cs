using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private DataContext _dataContext;

        private IEnumerable<Category> Categories => _dataContext.Categories;
        private IEnumerable<Supplier> Suppliers => _dataContext.Suppliers;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Products.Include(p => p.Category).Include(p => p.Supplier));
        }

        public async Task<IActionResult> Details(long id)
        {
            Product p = await _dataContext.Products.Include(p => p.Category).Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            ProductViewModel model = ViewModelFactory.Details(p);
            return View("ProductEditor", model);
        }

        public IActionResult Create()
        {
            return View("ProductEditor", ViewModelFactory.Create(new Product(), Categories, Suppliers));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if(ModelState.IsValid)
            {
                product.ProductId = default;
                product.Category = default;
                product.Supplier = default; 
                _dataContext.Products.Add(product);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ProductEditor", ViewModelFactory.Create(new Product(), Categories, Suppliers));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Product p = await _dataContext.Products.FindAsync(id);

            ProductViewModel model = ViewModelFactory.Edit(p, Categories, Suppliers);

            return View("ProductEditor",model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Product product)
        {
            if(ModelState.IsValid)
            {
                product.Category = default;
                product.Supplier = default;
                _dataContext.Products.Update(product);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ProductEditor", ViewModelFactory.Edit(product, Categories, Suppliers));
        }
    }
}
