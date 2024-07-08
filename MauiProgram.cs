using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Registro del servicio ApiService como IApiService
            builder.Services.AddSingleton<IApiService, ApiService>();

            return builder.Build();
        }
    }
}
