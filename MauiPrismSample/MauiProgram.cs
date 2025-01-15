using MauiPrismSample.ViewModels;
using MauiPrismSample.Views;
using Microsoft.Extensions.Logging;
using System.Reflection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MauiPrismSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism =>
                {
                    prism.RegisterTypes(container =>
                    {
                        container.RegisterForNavigation<MainPage, MainPageViewModel>();
                        container.RegisterForNavigation<SubPage, SubPageViewModel>();
                    });

                    prism.CreateWindow(
                        string.Format("NavigationPage/{0}", typeof(MainPageViewModel).Name), HandleNavigationError);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.RegisterViews();

            return builder.Build();
        }

        static void HandleNavigationError(Exception ex)
        {
            Console.WriteLine(ex);
            System.Diagnostics.Debugger.Break();
        }


        static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            Assembly viewAssembly = typeof(MainPage).GetTypeInfo().Assembly;
            var viewTypes = viewAssembly.GetTypes().Where(x => x.GetTypeInfo().IsSubclassOf(typeof(ContentPage))).ToList();

            var viewModelTypesDictionary = viewAssembly.GetTypes()
               .Where(x => x.GetTypeInfo().IsSubclassOf(typeof(ViewModelBase)))
               .ToDictionary(t => t.Name, t => t);

            foreach (Type type in viewTypes)
            {
                if (viewModelTypesDictionary.TryGetValue($"{type.Name}ViewModel", out Type viewModelType))
                {
                    builder.Services.RegisterForViewModelNavigation(type, viewModelType);
                    System.Diagnostics.Debug.WriteLine($"By Convention RegisterForViewModelNavigation: {type.Name} with {viewModelType.Name}");
                }
            }

            return builder;
        }

        public static IServiceCollection RegisterForViewModelNavigation(this IServiceCollection services, Type view, Type viewModel)
        {
            services.RegisterForNavigation(view, viewModel, viewModel.Name);
            return services;
        }
    }
}
