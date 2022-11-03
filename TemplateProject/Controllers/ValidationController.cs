using Microsoft.AspNetCore.Mvc;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private DataContext _dataContext;

        public ValidationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("categorykey")]
        public bool CategoryKey(string categoryid)
        {
            long keyVal;

            return long.TryParse(categoryid, out keyVal) && _dataContext.Categories.Find(keyVal) != null;
        }

        [HttpGet("supplierkey")]
        public bool SupplierKey(string supplierId)
        {
            long keyVal;
            return long.TryParse(supplierId, out keyVal) && _dataContext.Suppliers.Find(keyVal) != null;
        }
    }
}
