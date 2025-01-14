using System.Diagnostics;
using MauiPrismSample.ViewModels;

namespace MauiPrismSample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            Debug.WriteLine($"MainPage binding context: {BindingContext?.GetType().Name ?? "null"}");

            BindingContext = viewModel;

        }

    }

}
