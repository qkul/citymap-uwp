using Caliburn.Micro;
using CityMapUWP.Models;
using System;
using Windows.UI.Xaml.Media.Imaging;

namespace CityMapUWP.ViewModels
{
    public class CityDetailsViewModel : Screen
    {
        #region Fields
        private readonly INavigationService _navigationService;   
        private City _city;
        private BitmapImage _bitmapImageCity;
        #endregion

        #region Properties
        public City City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyOfPropertyChange(nameof(City));
            }
        }
       
        public BitmapImage ImageCity
        {
            get => _bitmapImageCity;
            set
            {
                _bitmapImageCity = value;
                NotifyOfPropertyChange(nameof(ImageCity));
            }
        }
        #endregion
        public CityDetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public City Parameter { get; set; }
        protected override void OnActivate()
        {
            base.OnActivate();
            City = Parameter;
            if (City != null) ImageCity = new BitmapImage(new Uri(City.ImageUrl));
        }       
    }
}
