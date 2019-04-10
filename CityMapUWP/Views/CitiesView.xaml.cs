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
      
    }
}
 
