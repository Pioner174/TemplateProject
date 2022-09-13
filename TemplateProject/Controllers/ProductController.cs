using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _dataContext.Products;
            
        }
        [HttpGet("{id}")]
        public Product GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("GetProduct Action Invoked");
            return _dataContext.Products.Find(id);
        }

        [HttpPost]
        public void SaveProduct([FromBody] Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            _dataContext.Products.Remove(new Product() { ProductId = id });
            _dataContext.SaveChanges();
        }
    }
}
