using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using System.Threading.Tasks;

namespace InterfazTicketsApp.Views
{
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage()
        {
            InitializeComponent();
            BindingContext = new EventDetailViewModel();
            BuyTicketsButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
            ShareEventButton.Clicked += async (sender, e) => await AnimateButton(sender as Button);
        }

        private async Task AnimateButton(Button button)
        {
            await button.ScaleTo(1.1, 100, Easing.CubicIn);
            await button.ScaleTo(1.0, 100, Easing.CubicOut);
        }
    }
}
