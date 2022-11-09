using Microsoft.AspNetCore.Mvc;
using TemplateProject.Filters;

namespace TemplateProject.Controllers
{
    [HttpsOnly]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        public IActionResult Secure()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

    }
}
