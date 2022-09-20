using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplateProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace TemplateProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private DataContext _context;

        public SuppliersController(DataContext dct)
        {
            _context = dct;
        }

        [HttpGet("{id}")]
        public async Task<Supplier> GetSupplier(long id)
        {
            Supplier supplier = await _context.Suppliers.Include(s => s.Products).FirstAsync(s => s.SupplierId == id);

            foreach(Product p in supplier.Products)
            {
                p.Supplier = null;
            }

            return supplier;
        }

        [HttpPatch("{id}")]
        public async Task<Supplier> PatchSupplier(long id, JsonPatchDocument<Supplier> patchDoc)
        {
            Supplier s = await _context.Suppliers.FindAsync(id);

            if(s != null)
            {
                patchDoc.ApplyTo(s);
                await _context.SaveChangesAsync();
            }

            return s;
        }
    }
}
