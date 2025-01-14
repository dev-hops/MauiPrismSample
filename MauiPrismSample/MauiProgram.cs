using MauiPrismSample.ViewModels;
using MauiPrismSample.Views;
using Microsoft.Extensions.Logging;

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
                    
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
