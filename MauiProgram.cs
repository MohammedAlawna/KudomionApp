using CommunityToolkit.Maui;
using Kudomion;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.ViewModels;
using KudomionApp.MVVM.Views;
using KudomionApp.Services;
using Microsoft.Extensions.Logging;

namespace KudomionApp
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()
            //builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Add Singelton: one instance for whole lifetime app.
            builder.Services.AddSingleton<IFirebaseChatService, FirebaseChatService>();
            builder.Services.AddTransient<PrivateChatViewModel>();
            builder.Services.AddSingleton<ChatListViewModel>();

            //Add Transient, a new instance every time it's needed (suitalbe for views, viewmodels).
            builder.Services.AddTransient<PrivateChat>();
            builder.Services.AddTransient<ChatList>();

         

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Store service provider:
            var app = builder.Build();
            Services = app.Services;

            return app;
        }
    }
}
