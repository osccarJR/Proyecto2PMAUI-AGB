using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    public partial class EventoDetallePage : ContentPage
    {
        public EventoDetallePage()
        {
            InitializeComponent();
            BindingContext = new EventoDetalleViewModel();
        }
    }
}