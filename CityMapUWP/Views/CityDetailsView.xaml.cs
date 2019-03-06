using CityMapUWP.Models;
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
        public CityDetailsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var city = e.Parameter as City;
            if (city != null)
            {
                CityImage.Source = new BitmapImage(new Uri(city.ImageUrl));
                NameTextBlock.Text = city.Name;
                DescriptionTextBlock.Text = city.Description;

            }
            base.OnNavigatedTo(e);
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
