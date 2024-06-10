using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class PurchaseViewModel : BindableObject
    {
        private string _ticketQuantity;
        private string _cardName;
        private string _cardNumber;
        private string _cardExpiry;
        private string _cardCVC;
        private DetailEvent _selectedEvent;

        public ObservableCollection<DetailEvent> Events { get; set; }
        public DetailEvent SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string TicketQuantity
        {
            get => _ticketQuantity;
            set
            {
                _ticketQuantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string CardName
        {
            get => _cardName;
            set
            {
                _cardName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string CardExpiry
        {
            get => _cardExpiry;
            set
            {
                _cardExpiry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string CardCVC
        {
            get => _cardCVC;
            set
            {
                _cardCVC = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public ICommand ConfirmPurchaseCommand { get; }

        public bool IsPurchaseEnabled =>
            SelectedEvent != null &&
            !string.IsNullOrWhiteSpace(TicketQuantity) &&
            !string.IsNullOrWhiteSpace(CardName) &&
            !string.IsNullOrWhiteSpace(CardNumber) &&
            !string.IsNullOrWhiteSpace(CardExpiry) &&
            !string.IsNullOrWhiteSpace(CardCVC);

        public PurchaseViewModel()
        {
            ConfirmPurchaseCommand = new Command(OnConfirmPurchase);
            Events = new ObservableCollection<DetailEvent>
            {
                new DetailEvent
                {
                    EventName = "Concierto de Rock",
                    EventImage = "rock.jpg",
                    EventDate = DateTime.Now.AddMonths(1),
                    EventLocation = "Teatro Nacional, Madrid",
                    EventDescription = "Disfruta de una noche mágica con la mejor música rock interpretada por Van Halen."
                },
                new DetailEvent
                {
                    EventName = "Festival de Jazz",
                    EventImage = "jazz.png",
                    EventDate = DateTime.Now.AddMonths(2),
                    EventLocation = "Parque Central, Barcelona",
                    EventDescription = "Un festival con los mejores exponentes del jazz mundial."
                }
            };
        }

        private async void OnConfirmPurchase()
        {
            await Application.Current.MainPage.DisplayAlert("Compra Exitosa", "¡Has comprado tus tickets exitosamente!", "OK");
        }
    }
}
