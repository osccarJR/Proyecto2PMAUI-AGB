using Microsoft.Maui.Controls;
using InterfazTicketsApp.Services;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp
{
    public partial class App : Application
    {
        public static ServicioCompra ServicioCompra { get; private set; }

        public App()
        {
            InitializeComponent();

            // Cambia esto a tu cadena de conexión real
            string connectionString = "Server=KEKIPC;Database=TicketsDB;Trusted_Connection=True;TrustServerCertificate=True;";

            ServicioCompra = new ServicioCompra(connectionString);

            MainPage = new AppShell();
        }
    }
}
