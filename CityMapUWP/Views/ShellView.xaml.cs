using CityMapUWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CityMapUWP.Views
{
    public sealed partial class ShellView : Page
    {
        public ShellViewModel ViewModel { get; set; }

        public ShellView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as ShellViewModel; };
        }

        private void OnMenuItemClick(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ViewModel.NavigateToSetting();

            }
            else
            {
                ViewModel.NavigateToClikedItemMenu((string)args.InvokedItem);
            }    
        }

        private void OnShellFrameLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitializeShellNavigationService(ContentFrame);
        }
    }
}