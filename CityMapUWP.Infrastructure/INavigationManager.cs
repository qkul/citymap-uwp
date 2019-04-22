using CityMapUWP.Models;
using System;
using System.Collections.Generic;

namespace CityMapUWP.Infrastructure
{
    public interface INavigationManager
    {
        void InitializeShellNavigationService(object navigationService);
        void NavigateToMap(IEnumerable<City> cities);
        void NavigateToDetails(City city);
        void NavigateToShellViewModel(Type viewModelType);      
        void NavigateToShellViewCities();
        void NavigateSetting();
        void GoBack();             
    }
}
