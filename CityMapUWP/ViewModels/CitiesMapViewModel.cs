using Caliburn.Micro;
using CityMapUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

namespace CityMapUWP.ViewModels
{
    public class CitiesMapViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        public CitiesMapViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private IEnumerable<City> _cities;
        private MapControl _mapCities;
        public IEnumerable<City> Parameter { get; set; }

        public IEnumerable<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                NotifyOfPropertyChange(nameof(Cities));
            }
        }

        public MapControl CitiesMapControl
        {
            get { return _mapCities; }
            set
            {
                _mapCities = value;
                NotifyOfPropertyChange(nameof(CitiesMapControl));
            }
        }
      
        //protected override void OnActivate()
        //{
        //    base.OnActivate();
        //    Cities = Parameter;
        //    if (_cities != null)
        //    {
        //        foreach (var city in _cities)
        //        {
        //            AddMapIcon(city);
        //        }
        //    }
        //}

        //private void AddMapIcon(City city)
        //{
        //    var location = new BasicGeoposition();
        //    var mapIcon = new MapIcon();

        //    location.Longitude = city.Longitude;
        //    location.Latitude = city.Latitude;

        //    if (mapIcon != null)
        //    {
        //        CitiesMapControl.MapElements.Remove(mapIcon);
        //    }
           
        //    mapIcon.Location = new Geopoint(location);
        //    mapIcon.Title = city.Name;

        //    CitiesMapControl.MapElements.Add(mapIcon);
        //    CitiesMapControl.Center = new Geopoint(location);
        //}
     
    }
}
