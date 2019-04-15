using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CityMapUWP.Views
{
    public sealed partial class SettingView : Page
    {
        public SettingView() => this.InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            CbxLanguages.ItemsSource = LocalizedResources.SupportedLanguages;
            CbxLanguages.SelectedIndex = Array.IndexOf(LocalizedResources.SupportedLanguages.ToArray(), LocalizedResources.Language);
        }

        private void CbxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbxLanguages.SelectedItem != null)
            {
                var language = CbxLanguages.SelectedItem as string;

                LocalizedResources.Language = language;

                Frame.Navigate(Frame.CurrentSourcePageType);
                Frame.BackStack.Clear();
            }
        }
    }
}

