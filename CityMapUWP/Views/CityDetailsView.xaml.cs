using CityMapUWP.Models;
using CityMapUWP.ViewModels;
using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


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
