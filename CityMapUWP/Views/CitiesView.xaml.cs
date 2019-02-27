using CityMapUWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CityMapUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CitiesView : Page
    {
        public CitiesView()
        {
            this.InitializeComponent();

            var citiesService = new CitiesService();
            CitiesListView.ItemsSource = citiesService.Cities;
        }

        private void CitiesListView_ItemClick(object sender, ItemClickEventArgs itemClickEvent)
        {
            Frame.Navigate(typeof(CityDetailsView), itemClickEvent.ClickedItem);
        }
    }
}
