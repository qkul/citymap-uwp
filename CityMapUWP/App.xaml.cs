using Caliburn.Micro;
using CityMapUWP.ViewModels;
using CityMapUWP.Views;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
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
           // _container.PerRequest<SettingViewModel>();
        }
        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (e.PreviousExecutionState == ApplicationExecutionState.Running)
                return;
            DisplayRootView<CitiesView>();
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
