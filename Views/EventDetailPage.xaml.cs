using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace InterfazTicketsApp
{
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage()
        {
          
            InitializeComponent();
            BindingContext = new EventDetailViewModel();
        }
    }

    public class DetaiilEvent
    {
        public string EventName { get; set; }
        public string EventImage { get; set; } // Path to the image
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
    }

    public class EventDetailViewModel : BindableObject
    {
        private DetaiilEvent _event;

        public EventDetailViewModel()
        {
            // Initialize the event with sample data
            _event = new DetaiilEvent
            {
                EventName = "Concierto de Rock",
                EventImage = "rock.jpg", // Replace with a valid image path in your project
                EventDate = DateTime.Now.AddMonths(1),
                EventLocation = "Teatro Nacional, Madrid",
                EventDescription = "Disfruta de una noche mágica con la mejor música rock interpretada por Van Halen."
            };

            BuyTicketsCommand = new Command(OnBuyTickets);
            ShareEventCommand = new Command(OnShareEvent);
        }

        public string EventName => _event.EventName;
        public string EventImage => _event.EventImage;
        public DateTime EventDate => _event.EventDate;
        public string EventLocation => _event.EventLocation;
        public string EventDescription => _event.EventDescription;

        public ICommand BuyTicketsCommand { get; }
        public ICommand ShareEventCommand { get; }

        private void OnBuyTickets()
        {
            // Handle buy tickets logic here
        }

        private void OnShareEvent()
        {
            // Handle share event logic here
        }
    }
}
