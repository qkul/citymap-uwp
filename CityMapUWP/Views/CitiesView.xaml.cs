using CityMapUWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        private const string NoInternetConection = "No internet conection";
        private const string NoData = "No Data";

        private CitiesService _citiesService;
        private NetworkService _networkService;
        public CitiesView()
        {
            this.InitializeComponent();
            _citiesService = new CitiesService();
            _networkService = new NetworkService();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeAsync();
            
        }

        private async Task InitializeAsync()
        {
            LoadingProgressRing.IsActive = true;
            var cities = await _citiesService.LoadCitiesAsync();
            LoadingProgressRing.IsActive = false;

            if (cities != null) CitiesGridView.ItemsSource = cities;
            else ShowNoData();

        }

        private void ShowNoData()
        {
            NoDataTextBlock.Text = _networkService.HasInternet() ? NoData : NoInternetConection;
            NoDataTextBlock.Visibility = Visibility.Visible;
        }

        private void CitiesGridView_ItemClick(object sender, ItemClickEventArgs itemClickEvent)
        {
            Frame.Navigate(typeof(CityDetailsView), itemClickEvent.ClickedItem);
        }
    }
}
