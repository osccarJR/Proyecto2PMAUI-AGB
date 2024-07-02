using Microsoft.Maui;
using Microsoft.Maui.Hosting;
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Agrega aquí tu cadena de conexión a SQL Server
            string connectionString = "your_connection_string_here";
            builder.Services.AddSingleton(new ServicioCompra(connectionString));

            return builder.Build();
        }
    }
}
