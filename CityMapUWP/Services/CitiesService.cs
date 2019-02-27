using CityMapUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityMapUWP.Services
{
    class CitiesService
    {
        public IEnumerable<City> Cities { get; } = new[]
       {
            new City { Name = "Minsk", Description = "Minsk is the capital of Belarus" },
            new City { Name = "Warsaw", Description ="Warsaw is the capital of Poland"},
            new City { Name = "Berlin", Description ="Berlin is the capital of Germany"},
            new City { Name = "Amsterdam", Description ="Amsterdam is the capital of Netherland"},
            new City { Name = "Olso", Description ="Olso is the capital of Norway"},
            new City { Name = "Lisbon", Description ="Lisbon is the capital of Portugal"},
            new City { Name = "Madrid", Description ="Madrid is the capital of Spain"},
            new City { Name = "Moscow", Description ="Moscow is the capital of Russia"},
            new City { Name = "Kiev", Description ="Kiev is the capital of Ukraine"},
            new City { Name = "Stockholm", Description ="Stockholm is the capital of Sweden"},
        }; 
    }
}
