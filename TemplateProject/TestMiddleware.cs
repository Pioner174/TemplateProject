using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject
{
    public class TestMiddleware
    {
        private RequestDelegate _nextDelegate;
        public TestMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext)
        {
            if (context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"В базе {dataContext.Products.Count()} продуктов.",System.Text.Encoding.GetEncoding(1251));
                await context.Response.WriteAsync($"\nВ базе {dataContext.Categories.Count()} категорий.", System.Text.Encoding.GetEncoding(1251));
                await context.Response.WriteAsync($"\nВ базе {dataContext.Suppliers.Count()} поставщиков.", System.Text.Encoding.GetEncoding(1251));
            }
            else
                await _nextDelegate(context);
        }
    }
}
