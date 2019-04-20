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
        #region Field and Constructor
        private readonly INavigationService _windowNavigationService;
        private INavigationService _shellNavigationService;
        public event EventHandler OnShellNavigationManagerNavigated;
        public NavigationManager(INavigationService navigationService)
        {
            _windowNavigationService = navigationService;        
        }
        #endregion

        #region Methods
        public void InitializeShellNavigationService(INavigationService navigationService)
        {
            _shellNavigationService = navigationService;
        }
        private void OnShellNavigationServiceNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
           
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            OnShellNavigationManagerNavigated?.Invoke(this, null);
        }

        public void InitializeShellNavigationService(object navigationService)
        {
            _shellNavigationService = (INavigationService)navigationService;
            _shellNavigationService.Navigated += OnShellNavigationServiceNavigated;
        }

        public void NavigateToShellViewCities()
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel<CitiesViewModel>();
        }



        public void NavigateSetting()
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel<SettingViewModel>();
        }



        public void NavigateToShellViewModel(Type viewModelType)
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel(viewModelType);
        }

        public void NavigateToDetails(City city)
        {
            _shellNavigationService.NavigateToViewModel<CityDetailsViewModel>(city);
        }

        public void NavigateToMap(IEnumerable<City> cities)
        {
            _shellNavigationService.NavigateToViewModel<CitiesMapViewModel>(cities);
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
            if (_shellNavigationService.CanGoBack)
            {
                _shellNavigationService.GoBack();
            }
        }
        #endregion
    }
}
