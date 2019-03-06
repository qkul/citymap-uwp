using CityMapUWP.Services;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace CityMapUWP.Views
{
    public sealed partial class CitiesView : Page
    {
        private const string NoInternetConection = "No internet conection";
        private const string NoData = "No Data";

        private readonly CitiesService _citiesService;
        private readonly NetworkService _networkService;
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

            if (cities != null)
            {
                CitiesGridView.ItemsSource = cities;
                CitiesMapButton.Visibility = Visibility.Visible;
            }
            else ShowNoData();

        }

        private void ShowNoData()
        {
            NoDataTextBlock.Text = _networkService.HasInternet() ? NoData : NoInternetConection;
            NoDataTextBlock.Visibility = Visibility.Visible;
        }

        private void CitiesGridView_ItemClick(object sender, ItemClickEventArgs itemClickEvent) => Frame.Navigate(typeof(CityDetailsView), itemClickEvent.ClickedItem);

        private void CitiesMapButton_Tapped(object sender, TappedRoutedEventArgs e) => Frame.Navigate(typeof(CitiesMapView), CitiesGridView.ItemsSource);
    }
}
 
