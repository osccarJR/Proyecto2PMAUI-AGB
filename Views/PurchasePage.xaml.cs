using Microsoft.Maui.Controls;
using System;

namespace InterfazTicketsApp
{
    public partial class PurchasePage : ContentPage
    {
        public PurchasePage()
        {
            InitializeComponent();
            // Inicializar con datos de ejemplo
            EventNameLabel.Text = "Concierto de Rock";
            EventDateLabel.Text = DateTime.Today.ToString("dd/MM/yyyy");
            EventLocationLabel.Text = "Madrid";
        }

        private void OnConfirmPurchase(object sender, EventArgs e)
        {
            // Obtener los valores de los controles
            string ticketQuantity = TicketQuantityEntry.Text;
            string cardName = CardNameEntry.Text;
            string cardNumber = CardNumberEntry.Text;
            string cardExpiry = CardExpiryEntry.Text;
            string cardCVC = CardCVCEntry.Text;

            // Aquí puedes añadir lógica de validación y procesamiento
            if (string.IsNullOrWhiteSpace(ticketQuantity) || string.IsNullOrWhiteSpace(cardName) ||
                string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(cardExpiry) || string.IsNullOrWhiteSpace(cardCVC))
            {
                DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Simular la compra
            DisplayAlert("Compra Realizada", "¡Gracias por su compra!", "OK");
        }
    }
}
