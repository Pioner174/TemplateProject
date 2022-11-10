﻿using Microsoft.AspNetCore.Mvc;
using TemplateProject.Filters;

namespace TemplateProject.Controllers
{
    
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

        [ChangeArg]
        public IActionResult Messages(string message1, string message2 = "None")
        {
            return View("Message", $"{message1}, {message2}");
        }

    }
}
