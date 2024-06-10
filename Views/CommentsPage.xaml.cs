using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    public partial class CommentsPage : ContentPage
    {
        public CommentsPage()
        {
            InitializeComponent();
            BindingContext = new CommentsViewModel();
            SubmitButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
            LoadButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
            SaveButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
        }

        private async Task AnimateButton(Button button)
        {
            await button.ScaleTo(1.1, 100);
            await button.ScaleTo(1.0, 100);
        }
    }
}
