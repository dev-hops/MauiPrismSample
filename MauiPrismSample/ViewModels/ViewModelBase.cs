using Microsoft.Maui.Controls;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MauiPrismSample.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IInitialize, IDisposable
    {
        protected INavigationService NavigationService { get; }
        protected CompositeDisposable Disposables { get; } = new();

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposables?.Dispose();
            }
        }
    }
}