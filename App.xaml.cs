using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp
{
    public partial class App : Application
    {
        public static IApiService ApiService { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public App(IApiService apiService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            ApiService = apiService;
        }
    }
}
