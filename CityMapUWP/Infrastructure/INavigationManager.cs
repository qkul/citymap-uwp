using CityMapUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityMapUWP.Infrastructure
{
    public interface INavigationManager
    {

        void InitializeShellNavigationService(object navigationService);
        void NavigateToShellViewCities();
        void NavigateToShellViewModel(Type viewModelType);
        void GoBack();
        void NavigateToDetails(City city);
        void NavigateToMap(IEnumerable<City> cities);


    }
}
