using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class PurchaseViewModel : BindableObject
    {
        public string TicketQuantity { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CardCVC { get; set; }
        public ICommand ConfirmPurchaseCommand { get; set; }

        public PurchaseViewModel()
        {
            ConfirmPurchaseCommand = new Command(OnConfirmPurchase);
        }

        private void OnConfirmPurchase()
        {
            // Handle purchase logic here
        }
    }
}
