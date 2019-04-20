using Caliburn.Micro;
using CityMapUWP.Infrastructure;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace CityMapUWP.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly INavigationManager _navigationManager;

        private readonly IDictionary<string, Type> _mainMenuPages = new Dictionary<string, Type>()
        {
            {"Language",  typeof(SettingViewModel)},
            {"Home", typeof(CitiesViewModel) }
        };

        public ShellViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void InitializeShellNavigationService(Frame frame)
        {
            _navigationManager.InitializeShellNavigationService(new FrameAdapter(frame));
            _navigationManager.NavigateToShellViewCities();
        }

        public void Naviga()
        {
            _navigationManager.NavigateSetting();

        }

        public void NavigateToClikedItemMenu(string value)
        {
           
            _navigationManager.NavigateToShellViewModel(_mainMenuPages[value]);
        }
    }
}

