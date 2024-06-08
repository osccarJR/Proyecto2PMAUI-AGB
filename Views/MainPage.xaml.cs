using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
