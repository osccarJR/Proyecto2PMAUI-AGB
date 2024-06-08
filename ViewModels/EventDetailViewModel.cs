using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class EventDetailViewModel : BindableObject
    {
        private DetaiilEvent _event;

        public EventDetailViewModel()
        {
            _event = new DetaiilEvent
            {
                EventName = "Concierto de Rock",
                EventImage = "rock.jpg",
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

    public class DetaiilEvent
    {
        public string EventName { get; set; }
        public string EventImage { get; set; } // Path to the image
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
    }
}
