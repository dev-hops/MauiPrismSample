using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace MauiPrismSample.ViewModels
{
    public class SubPageViewModel : ViewModelBase
    {
        private string _title = "Sub Page";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ReactiveCommand<Unit, INavigationResult> GoBackCommand { get; }

        public SubPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GoBackCommand = ReactiveCommand.CreateFromTask(async () => await NavigationService.GoBackAsync());
        }
    }
}