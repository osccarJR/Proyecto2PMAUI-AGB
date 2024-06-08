using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    public partial class PurchasePage : ContentPage
    {
        public PurchasePage()
        {
            InitializeComponent();
            BindingContext = new PurchaseViewModel();
            // Inicializar con datos de ejemplo
            EventNameLabel.Text = "Concierto de Rock";
            EventDateLabel.Text = DateTime.Today.ToString("dd/MM/yyyy");
            EventLocationLabel.Text = "Madrid";
        }
    }
}
