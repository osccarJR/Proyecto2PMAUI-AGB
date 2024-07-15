using System.Windows.Input;
using Microsoft.Maui.Controls;
using System;

namespace InterfazTicketsApp.ViewModels
{
    public class EventoDetalleViewModel : BindableObject
    {
        private string _eventName;
        private string _eventImage;
        private DateTime _eventDate;
        private string _eventLocation;
        private string _eventDescription;
        private decimal _ticketPrice;

        public string EventName
        {
            get => _eventName;
            set
            {
                _eventName = value;
                OnPropertyChanged();
            }
        }

        public string EventImage
        {
            get => _eventImage;
            set
            {
                _eventImage = value;
                OnPropertyChanged();
            }
        }

        public DateTime EventDate
        {
            get => _eventDate;
            set
            {
                _eventDate = value;
                OnPropertyChanged();
            }
        }

        public string EventLocation
        {
            get => _eventLocation;
            set
            {
                _eventLocation = value;
                OnPropertyChanged();
            }
        }

        public string EventDescription
        {
            get => _eventDescription;
            set
            {
                _eventDescription = value;
                OnPropertyChanged();
            }
        }

        public decimal TicketPrice
        {
            get => _ticketPrice;
            set
            {
                _ticketPrice = value;
                OnPropertyChanged();
            }
        }

        public ICommand BuyTicketsCommand { get; }
        public ICommand GoBackCommand { get; }

        public EventoDetalleViewModel()
        {
            BuyTicketsCommand = new Command(OnBuyTickets);
            GoBackCommand = new Command(OnGoBack);
        }

        public void Initialize(string eventName, string eventDescription, string eventImage, string eventLocation, DateTime eventDate, decimal ticketPrice)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            EventImage = eventImage;
            EventLocation = eventLocation;
            EventDate = eventDate;
            TicketPrice = ticketPrice;
        }

        private async void OnBuyTickets()
        {
            await Shell.Current.GoToAsync("//Compra");
        }

        private async void OnGoBack()
        {
            await Shell.Current.GoToAsync("//Buscar");
        }
    }
}
