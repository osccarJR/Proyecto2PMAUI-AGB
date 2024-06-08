using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    public partial class CommentsPage : ContentPage
    {
        public CommentsPage()
        {
            InitializeComponent();
            BindingContext = new CommentsViewModel();
        }
    }
}
