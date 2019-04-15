using CityMapUWP.ViewModels;
using Windows.UI.Xaml.Controls;


namespace CityMapUWP.Views
{
    public sealed partial class CityDetailsView : Page
    {
        public CityDetailsViewModel ViewModel { get; set; }
        public CityDetailsView()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as CityDetailsViewModel; };
        }
    }
}
