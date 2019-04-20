using Caliburn.Micro;
using CityMapUWP.Infrastructure;
using CityMapUWP.Models;
using CityMapUWP.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CityMapUWP.ViewModels
{
    public class CitiesViewModel : Screen
    {
        #region Fields

        private const string NoInternetConection = "No internet conection";
        private const string NoData = "No Data";

        //   private readonly INavigationService _navigationService;
        private readonly INavigationManager _navigationManager;
        private CitiesService _citiesService;
        private NetworkService _networkService;
        private IEnumerable<City> _cities;
        private bool _isLoadingProgressRing;
        private Visibility _citiesMapButton;
        private Visibility _visibilityNoData;
        private string _noDataTextBl;
        #endregion

        #region Properties    
        public IEnumerable<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                NotifyOfPropertyChange(() => Cities);
            }
        }
    
        public string NoDataTextBl
        {
            get => _noDataTextBl;
            set
            {
                _noDataTextBl = value;
                NotifyOfPropertyChange(() => NoDataTextBl);
            }
        }

        public bool IsLoadingProgressRing
        {
            get => _isLoadingProgressRing;
            set
            {
                _isLoadingProgressRing = value;
                NotifyOfPropertyChange(() => IsLoadingProgressRing);
            }
        }
       
        public Visibility VisibilityCitiesMapButton
        {
            get => _citiesMapButton;
            set
            {
                _citiesMapButton = value;
                NotifyOfPropertyChange(() => VisibilityCitiesMapButton);
            }
        }
      
        public Visibility VisibilityNoData
        {
            get => _visibilityNoData;
            set
            {
                _visibilityNoData = value;
                NotifyOfPropertyChange(() => VisibilityNoData);
            }
        }
        #endregion
        public CitiesViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _citiesService = new CitiesService();
            _networkService = new NetworkService();

        }
        
        #region Methods
        public void NavigateToCityDetails(City city)
        {
            // _navigationManager.NavigateToViewModel<CityDetailsViewModel>(city);
            _navigationManager.NavigateToDetails(city);
        }
        public void NavigateToCitiesMap(IEnumerable<City> cities)
        {
            //_navigationService.NavigateToViewModel<CitiesMapViewModel>(cities);
            _navigationManager.NavigateToMap(cities);
        }
      
        protected override async void OnActivate()
        {
            await InitializeAsync();
            base.OnActivate();
        }

        private async Task InitializeAsync()
        {
            VisibilityNoData = Visibility.Collapsed;
            VisibilityCitiesMapButton = Visibility.Collapsed;
            IsLoadingProgressRing = true;
            var cities = await new CitiesService().LoadCitiesAsync();
            IsLoadingProgressRing = false;

            if (cities != null)
            {
                Cities = cities;
                VisibilityCitiesMapButton = Visibility.Visible;
            }
            else ShowNoData();

        }
        private void ShowNoData()
        {
            NoDataTextBl = _networkService.HasInternet() ? NoData : NoInternetConection;
            VisibilityNoData = Visibility.Visible;
        }
        #endregion
    }
}
