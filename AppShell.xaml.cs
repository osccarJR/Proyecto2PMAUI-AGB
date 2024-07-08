using Microsoft.Maui.Controls;
using InterfazTicketsApp.Views;

namespace InterfazTicketsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
        }
    }
}
