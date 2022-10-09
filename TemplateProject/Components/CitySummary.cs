using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke()
        {
            /// Возвращение html разметки
            //return Content("This is a <h3><i>string</i></h3>");

            ///Возвращение отображенгия
            return View( new CityViewModel { Cities = _cityData.Cities.Count(), 
            Population= _cityData.Cities.Sum(p=> p.Population)});
        }
    }
}
