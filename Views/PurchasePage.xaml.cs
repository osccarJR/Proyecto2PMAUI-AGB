using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.Views
{
    public partial class PurchasePage : ContentPage
    {
        public PurchasePage()
        {
            InitializeComponent();
            BindingContext = new PurchaseViewModel(App.ApiService);
        }
    }
}
