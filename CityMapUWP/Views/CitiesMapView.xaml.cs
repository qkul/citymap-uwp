using CityMapUWP.Models;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace CityMapUWP.Views
{
    public sealed partial class CitiesMapView : Page
    {
        public CitiesMapView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
       
            var cities = e.Parameter as IEnumerable<City>;

            if (cities != null)
            {
                foreach (var city in cities)
                {
                    AddMapIcon(city);
                }
            }
            base.OnNavigatedTo(e);
        }

        private void AddMapIcon(City city)
        {
            var location = new BasicGeoposition();
            var mapIcon = new MapIcon();

            location.Longitude = city.Longitude;
            location.Latitude = city.Latitude;

            if (mapIcon != null)
            {
                CitiesMapControl.MapElements.Remove(mapIcon);
            }

            mapIcon.Location = new Geopoint(location);
            mapIcon.Title = city.Name;

            CitiesMapControl.MapElements.Add(mapIcon);
            CitiesMapControl.Center = new Geopoint(location);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
    }
}
