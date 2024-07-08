using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class EventDetailViewModel : BindableObject
    {
        private string _eventName;
        private string _eventImage;
        private DateTime _eventDate;
        private string _eventLocation;
        private string _eventDescription;
        private string _localidadesImage;

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

        public string LocalidadesImage
        {
            get => _localidadesImage;
            set
            {
                _localidadesImage = value;
                OnPropertyChanged();
            }
        }

        public ICommand BuyTicketsCommand { get; }
        public ICommand GoBackCommand { get; }

        public EventDetailViewModel()
        {
            BuyTicketsCommand = new Command(OnBuyTickets);
            GoBackCommand = new Command(OnGoBack);
        }

        private async void OnBuyTickets()
        {
            // Navegar a la pestaña de Compra
            await Shell.Current.GoToAsync("//Compra");
        }

        private async void OnGoBack()
        {
            // Navegar a la pestaña de Buscar
            await Shell.Current.GoToAsync("//Buscar");
        }
    }
}

