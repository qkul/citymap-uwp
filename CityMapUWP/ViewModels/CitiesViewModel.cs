using Caliburn.Micro;
using CityMapUWP.Models;
using CityMapUWP.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CityMapUWP.ViewModels
{
    public class CitiesViewModel : Screen
    {
        private const string NoInternetConection = "No internet conection";
        private const string NoData = "No Data";

        private readonly INavigationService _navigationService;
        private CitiesService _citiesService;
        private NetworkService _networkService;
    
        public CitiesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _citiesService = new CitiesService();
            _networkService = new NetworkService();
        }
        private IEnumerable<City> _cities;
        private bool _isLoadingProgressRing;
        private Visibility _citiesMapButton;
        private Visibility _visibilityNoData;
        private string _noDataTextBl;
      
        public IEnumerable<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                NotifyOfPropertyChange(() => Cities);
            }
        }
    
        public string NoDataTextBl
        {
            get { return _noDataTextBl; }
            set
            {
                _noDataTextBl = value;
                NotifyOfPropertyChange(() => NoDataTextBl);
            }
        }

        public bool IsLoadingProgressRing
        {
            get { return _isLoadingProgressRing; }
            set
            {
                _isLoadingProgressRing = value;
                NotifyOfPropertyChange(() => IsLoadingProgressRing);
            }
        }
       
        public Visibility VisibilityCitiesMapButton
        {
            get { return _citiesMapButton; }
            set
            {
                _citiesMapButton = value;
                NotifyOfPropertyChange(() => VisibilityCitiesMapButton);
            }
        }
      
        public Visibility VisibilityNoData
        {
            get { return _visibilityNoData; }
            set
            {
                _visibilityNoData = value;
                NotifyOfPropertyChange(() => VisibilityNoData);
            }
        }

        private async Task InitializeAsync()
        {
            VisibilityNoData = Visibility.Collapsed;
            VisibilityCitiesMapButton = Visibility.Collapsed;
            IsLoadingProgressRing = true;
            // var cities = await _citiesService.LoadCitiesAsync();
            var cities = await new CitiesService().LoadCitiesAsync();
            IsLoadingProgressRing = false;

            if (cities != null)
            {
                Cities = cities;
                VisibilityCitiesMapButton = Visibility.Visible;
            }
            else ShowNoData();

        }
        protected override async void OnViewLoaded(object view)
        {
            await InitializeAsync();
            base.OnViewLoaded(view);
        }
        private void ShowNoData()
        {
         //   NoDataTextBl = _networkService.HasInternet() ? NoData : NoInternetConection;
            VisibilityNoData = Visibility.Visible;
        }
        public void NavigateToCityDetails(City city)
        {
            _navigationService.NavigateToViewModel<CityDetailsViewModel>(city);
        }
        public void NavigateToCitiesMap(IEnumerable<City> cities)
        {
            _navigationService.NavigateToViewModel<CitiesMapViewModel>(cities);
        }
    }
}
