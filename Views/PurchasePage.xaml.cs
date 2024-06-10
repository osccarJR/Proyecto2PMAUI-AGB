using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using System.Threading.Tasks;

namespace InterfazTicketsApp.Views
{
    public partial class PurchasePage : ContentPage
    {
        public PurchasePage()
        {
            InitializeComponent();
            BindingContext = new PurchaseViewModel();
            ConfirmPurchaseButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
            // Inicializar con datos de ejemplo
            EventNameLabel.Text = "Concierto de Rock";
            EventDateLabel.Text = DateTime.Today.ToString("dd/MM/yyyy");
            EventLocationLabel.Text = "Madrid";
        }

        private async Task AnimateButton(Button button)
        {
            await button.ScaleTo(1.1, 100, Easing.CubicIn);
            await button.ScaleTo(1.0, 100, Easing.CubicOut);
        }
    }
}
