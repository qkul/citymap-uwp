using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class SettingView : Page
    {
        public SettingView()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

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

