using System.Collections.Generic;

namespace TemplateProject.Models
{
    public class CitiesData
    {
        private List<City> _cityList = new List<City> 
        {
            new City { Name = "London", Country ="UK" , Population = 5676390},
            new City { Name = "New York", Country ="USA" , Population = 8700000},
            new City { Name = "Kiev", Country ="Ukraina" , Population = 3450000},
            new City { Name = "Antalya", Country ="Turkey" , Population = 789000}
        };

        public IEnumerable<City> Cities => _cityList;

        public void AddCity(City newCity)
        {
            _cityList.Add(newCity);
        }

    }
}
