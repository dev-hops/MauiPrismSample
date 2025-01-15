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
        }
    }
}
