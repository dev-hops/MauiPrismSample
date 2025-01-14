using DryIoc;
using DryIoc.ImTools;
using MauiPrismSample.ViewModels;
using Microsoft.Maui.Controls;
using Prism.Ioc;
using Prism.Navigation;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace MauiPrismSample
{
    public partial class App : Application
    {        
        private readonly IContainerProvider _containerProvider;
            
        public App(IContainerProvider containerProvider)
        {
            InitializeComponent();
            _containerProvider = containerProvider;
        }

        protected override async void OnStart()
        {
            base.OnStart();

            var navigationService = _containerProvider.Resolve<INavigationService>();
            var mainPageViewModel = _containerProvider.Resolve<MainPageViewModel>();
            Debug.Assert(mainPageViewModel != null, "MainPageViewModel not found");

            var result = await navigationService.NavigateAsync("/NavigationPage/MainPage");


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage());
        }
    }
}
