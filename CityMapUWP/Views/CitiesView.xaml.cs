using CityMapUWP.Models;
using CityMapUWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
    }
}
 
