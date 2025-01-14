using Prism.Navigation;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace MauiPrismSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _title = "Main Page";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ReactiveCommand<Unit, INavigationResult> NavigateToSubPageCommand { get; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToSubPageCommand = ReactiveCommand.CreateFromTask(async () => await NavigationService.NavigateAsync("SubPage"));
        }
    }
}