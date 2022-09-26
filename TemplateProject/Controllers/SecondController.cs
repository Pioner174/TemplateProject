using Microsoft.AspNetCore.Mvc;

namespace TemplateProject.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View("Common");
        }

    }
}
