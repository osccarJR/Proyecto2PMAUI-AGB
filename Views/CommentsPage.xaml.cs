using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.Views
{
    public partial class CommentsPage : ContentPage
    {
        public CommentsPage()
        {
            InitializeComponent();
            BindingContext = new CommentsViewModel(App.ApiService);
        }
    }
}
