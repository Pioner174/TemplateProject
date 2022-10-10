using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateProject.Components
{
    public class PageSize : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage responce = await client.GetAsync("http://apress.com");
                return View(responce.Content.Headers.ContentLength);
            }
            catch
            {
                return View(long.Parse("44"));
            }
            
        }
    }
}
