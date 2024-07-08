using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.Views
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            BindingContext = new UserProfileViewModel(App.ApiService);
        }
    }
}
