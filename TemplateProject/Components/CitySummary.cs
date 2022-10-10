﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;
using TemplateProject.Models;

namespace TemplateProject.Components
{
    public class CitySummary : ViewComponent
    {
        private CitiesData _cityData;

        public CitySummary(CitiesData cityData)
        {
            _cityData = cityData;
        }

        public IViewComponentResult Invoke( string themeName)
        {
            /// Возвращение html разметки
            //return Content("This is a <h3><i>string</i></h3>");

            ///Возвращение отображенгия
            //return View( new CityViewModel { Cities = _cityData.Cities.Count(), 
            //Population= _cityData.Cities.Sum(p=> p.Population)});

            /// Возвращение фрагмента html разметки
            //return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));

            /// Испольхование данных марщрутизации
            //if (RouteData.Values["controller"] != null)
            //{
            //    return "Controller Request";
            //}
            //else
            //    return "Razor Page Request";

            ViewBag.Theme = themeName;

            return View(new CityViewModel { Cities = _cityData.Cities.Count(), Population = _cityData.Cities.Sum(c => c.Population)});
        }
    }
}
