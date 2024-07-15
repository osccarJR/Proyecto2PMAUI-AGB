﻿using Microsoft.Maui.Controls;
using InterfazTicketsApp.Data;
using System.IO;

namespace InterfazTicketsApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        static WeatherDatabase database;
        public static string DatabasePath;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "weather.db3");
            MainPage = new AppShell();
        }

        public static WeatherDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WeatherDatabase(DatabasePath);
                }
                return database;
            }
        }
    }
}





