using Caliburn.Micro;
using CityMapUWP.Infrastructure;
using CityMapUWP.ViewModels;
using CityMapUWP.Views;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace CityMapUWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App 
    {
        private WinRTContainer _container;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<CitiesViewModel>();
            _container.PerRequest<CityDetailsViewModel>();
            _container.PerRequest<CitiesMapViewModel>();
            _container.PerRequest<ShellViewModel>();
            _container.PerRequest<SettingViewModel>();
         //   _container.PerRequest<MainViewModel>();
   
            _container.Singleton<INavigationManager, NavigationManager>();

        }
        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (e.PreviousExecutionState == ApplicationExecutionState.Running)
                return;
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            DisplayRootView<CitiesView>();
        }
        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            var navigationManager = _container.GetInstance<INavigationManager>();
            navigationManager.GoBack();
            e.Handled = true;
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
