using Caliburn.Micro;
using CityMapUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CityMapUWP.ViewModels
{
    public class CityDetailsViewModel : Screen
    {
        private readonly INavigationService _navigationService;

        public CityDetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private City _city;
        private BitmapImage _bitmapImageCity;
        public City Parameter { get; set; }
        public City City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(nameof(City));
            }
        }
       
        public BitmapImage ImageCity
        {
            get { return _bitmapImageCity; }
            set
            {
                _bitmapImageCity = value;
                NotifyOfPropertyChange(nameof(ImageCity));
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            City = Parameter;
            if (City != null) ImageCity = new BitmapImage(new Uri(City.ImageUrl));

        }       
    }
}
