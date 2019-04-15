using Caliburn.Micro;
using CityMapUWP.Infrastructure;
using CityMapUWP.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Core;


namespace CityMapUWP.ViewModels
{
    public class NavigationManager : INavigationManager
    {
        public INavigationService windowNavigationService;
        public INavigationService shellNavigationService;
        public event EventHandler OnShellNavigationManagerNavigated;
        public NavigationManager(INavigationService navigationService)
        {
            windowNavigationService = navigationService;        
        }

        
        public void InitializeShellNavigationService(INavigationService navigationService)
        {
            shellNavigationService = navigationService;
        }
        private void OnShellNavigationServiceNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
           
            SetBackButtonVisibility(shellNavigationService.CanGoBack);
            OnShellNavigationManagerNavigated?.Invoke(this, null);
        }

        public void InitializeShellNavigationService(object navigationService)
        {
            shellNavigationService = (INavigationService)navigationService;
            shellNavigationService.Navigated += OnShellNavigationServiceNavigated;
        }

        public void NavigateToShellViewCities()
        {
            SetBackButtonVisibility(shellNavigationService.CanGoBack);
            shellNavigationService.NavigateToViewModel<CitiesViewModel>();
        }
      
        public void NavigateToShellViewModel(Type viewModelType)
        {
            SetBackButtonVisibility(shellNavigationService.CanGoBack);
            shellNavigationService.NavigateToViewModel(viewModelType);
        }

        public void NavigateToDetails(City city)
        {
            shellNavigationService.NavigateToViewModel<CityDetailsViewModel>(city);
        }

        public void NavigateToMap(IEnumerable<City> cities)
        {
            shellNavigationService.NavigateToViewModel<CitiesMapViewModel>(cities);
        }


        private void SetBackButtonVisibility(bool value)
        {
               SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
               value ?
               AppViewBackButtonVisibility.Visible :
               AppViewBackButtonVisibility.Collapsed;
        }

        public void GoBack()
        {
            if (shellNavigationService.CanGoBack)
            {
                shellNavigationService.GoBack();
            }
        }
    }

}
