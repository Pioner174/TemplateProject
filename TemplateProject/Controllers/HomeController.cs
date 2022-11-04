using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TemplateProject.Models;

namespace TemplateProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Message","This is the Index action on the Home controller");
        }

    }
}
