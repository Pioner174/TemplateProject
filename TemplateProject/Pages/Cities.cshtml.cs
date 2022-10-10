using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using TemplateProject.Models;

namespace TemplateProject.Pages
{
    [ViewComponent (Name = "CitiesPageHybrid")]
    public class CitiesModel : PageModel
    {
        public CitiesData Data { get; set; }

        public CitiesModel(CitiesData cities)
        {
            Data = cities;
        }

        [ViewComponentContext]
        public ViewComponentContext Context { get; set; }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<CityViewModel>(
                    Context.ViewData,
                    new CityViewModel { Cities = Data.Cities.Count(), Population = Data.Cities.Sum(c => c.Population) }
                    )
            };
        }
    }
}
