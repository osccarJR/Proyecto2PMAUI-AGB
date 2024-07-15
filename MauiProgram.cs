﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using InterfazTicketsApp.Services;
using InterfazTicketsApp.ViewModels;

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

            // Registra ApiService e instancias de ViewModel
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<PurchaseViewModel>();

            return builder.Build();
        }
    }
}



