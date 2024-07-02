using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;

namespace InterfazTicketsApp.Views
{
    [QueryProperty(nameof(EventName), "eventName")]
    [QueryProperty(nameof(EventDescription), "eventDescription")]
    [QueryProperty(nameof(EventImage), "eventImage")]
    [QueryProperty(nameof(EventLocation), "eventLocation")]
    [QueryProperty(nameof(EventDate), "eventDate")]
    [QueryProperty(nameof(LocalidadesImage), "localidadesImage")]
    public partial class EventDetailPage : ContentPage
    {
        public string EventName
        {
            set => ((EventDetailViewModel)BindingContext).EventName = Uri.UnescapeDataString(value ?? string.Empty);
        }
        public string EventDescription
        {
            set => ((EventDetailViewModel)BindingContext).EventDescription = Uri.UnescapeDataString(value ?? string.Empty);
        }
        public string EventImage
        {
            set => ((EventDetailViewModel)BindingContext).EventImage = Uri.UnescapeDataString(value ?? string.Empty);
        }
        public string EventLocation
        {
            set => ((EventDetailViewModel)BindingContext).EventLocation = Uri.UnescapeDataString(value ?? string.Empty);
        }
        public string EventDate
        {
            set => ((EventDetailViewModel)BindingContext).EventDate = DateTime.Parse(Uri.UnescapeDataString(value ?? string.Empty));
        }
        public string LocalidadesImage
        {
            set => ((EventDetailViewModel)BindingContext).LocalidadesImage = Uri.UnescapeDataString(value ?? string.Empty);
        }

        public EventDetailPage()
        {
            InitializeComponent();
            BindingContext = new EventDetailViewModel();
        }
    }
}
