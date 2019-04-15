using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CityMapUWP.UserControls
{
    public sealed partial class NavigationControl : UserControl
    {
        public string NavigationTitle
        {
            get { return (string)GetValue(dependencyProperty); }
            set { SetValue(dependencyProperty, value); }
        }

        public static readonly DependencyProperty dependencyProperty =
            DependencyProperty.Register("NavigationTitle", typeof(string), typeof(NavigationControl), null);

        public NavigationControl() => this.InitializeComponent();
    }
}
