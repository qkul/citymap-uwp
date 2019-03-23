using CityMapUWP.Models;
using CityMapUWP.Services;
using CityMapUWP.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace CityMapUWP.Views
{
    public sealed partial class CitiesView : Page
    {
        public CitiesViewModel ViewModel { get; set; }

        public CitiesView()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as CitiesViewModel; };
        }
        private void OnClickCitiesListClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToCityDetails(e.ClickedItem as City);
        }
        private void OnClickCitiesMap(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToCitiesMap(ViewModel.Cities);
        }
        //public async void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    await InitializeAsync();
        //}

        //private async Task InitializeAsync()
        //{
        //    LoadingProgressRing.IsActive = true;
        //    var cities = await _citiesService.LoadCitiesAsync();
        //    LoadingProgressRing.IsActive = false;

        //    if (cities != null)
        //    {
        //        CitiesGridView.ItemsSource = cities;
        //        CitiesMapButton.Visibility = Visibility.Visible;
        //    }
        //    else ShowNoData();

        //}

        //private void ShowNoData()
        //{
        //    NoDataTextBlock.Text = _networkService.HasInternet() ? NoData : NoInternetConection;
        //    NoDataTextBlock.Visibility = Visibility.Visible;
        //}

        //private void CitiesGridView_ItemClick(object sender, ItemClickEventArgs itemClickEvent)
        //{
        //    Frame.Navigate(typeof(CityDetailsView), itemClickEvent.ClickedItem);
        //}

        //private void CitiesMapButton_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(CitiesMapView), CitiesGridView.ItemsSource);
        //}

      
    }
}
 
