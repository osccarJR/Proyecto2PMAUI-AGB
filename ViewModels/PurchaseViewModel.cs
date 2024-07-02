using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.ViewModels
{
    public class PurchaseViewModel : BindableObject
    {
        private readonly ServicioCompra _servicioCompra;

        private string _ticketQuantity;
        private string _cardName;
        private string _cardNumber;
        private string _cardExpiry;
        private string _cardCVC;
        private DetailEvent _selectedEvent;
        private string _selectedCategory;
        private double _totalAmount;
        private string _holderName;
        private string _holderId;

        public ObservableCollection<DetailEvent> Events { get; set; }
        public ObservableCollection<string> TicketCategories { get; set; }

        public DetailEvent SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
                UpdateCategories();
                CalculateTotalAmount();
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
                CalculateTotalAmount();
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

        public string HolderName
        {
            get => _holderName;
            set
            {
                _holderName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string HolderId
        {
            get => _holderId;
            set
            {
                _holderId = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                CalculateTotalAmount();
                OnPropertyChanged(nameof(IsPurchaseEnabled));
            }
        }

        public double TotalAmount
        {
            get => _totalAmount;
            private set
            {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmPurchaseCommand { get; }

        public bool IsPurchaseEnabled =>
            SelectedEvent != null &&
            !string.IsNullOrWhiteSpace(TicketQuantity) &&
            !string.IsNullOrWhiteSpace(SelectedCategory) &&
            !string.IsNullOrWhiteSpace(CardName) &&
            !string.IsNullOrWhiteSpace(CardNumber) &&
            !string.IsNullOrWhiteSpace(CardExpiry) &&
            !string.IsNullOrWhiteSpace(CardCVC) &&
            !string.IsNullOrWhiteSpace(HolderName) &&
            !string.IsNullOrWhiteSpace(HolderId) &&
            HolderId.Length == 10;

        public PurchaseViewModel(ServicioCompra servicioCompra)
        {
            _servicioCompra = servicioCompra;
            ConfirmPurchaseCommand = new Command(OnConfirmPurchase);
            Events = new ObservableCollection<DetailEvent>
            {
                new DetailEvent
                {
                    EventName = "Concierto de Rock",
                    EventImage = "rock.jpg",
                    EventDate = DateTime.Now.AddMonths(1),
                    EventLocation = "Teatro Nacional, Madrid",
                    EventDescription = "Disfruta de una noche mágica con la mejor música rock interpretada por Van Halen.",
                    Category = "Conciertos",
                    LocalidadesImage = "localidades3.jpg"
                },
                new DetailEvent
                {
                    EventName = "Festival de Jazz",
                    EventImage = "jazz.png",
                    EventDate = DateTime.Now.AddMonths(2),
                    EventLocation = "Parque Central, Barcelona",
                    EventDescription = "Un festival con los mejores exponentes del jazz mundial.",
                    Category = "Conciertos",
                    LocalidadesImage = "localidades3.jpg"
                },
                new DetailEvent
                {
                    EventName = "Partido de Fútbol",
                    EventImage = "futbol.jpg",
                    EventDate = DateTime.Now.AddMonths(1),
                    EventLocation = "Estadio Santiago Bernabéu, Madrid",
                    EventDescription = "Real Madrid vs Barcelona en un emocionante clásico.",
                    Category = "Deportes",
                    LocalidadesImage = "localidades1.jpg"
                },
                new DetailEvent
                {
                    EventName = "Maratón de Nueva York",
                    EventImage = "maraton.jpg",
                    EventDate = DateTime.Now.AddMonths(3),
                    EventLocation = "Nueva York, USA",
                    EventDescription = "Únete a miles de corredores en una de las maratones más famosas del mundo.",
                    Category = "Deportes",
                    LocalidadesImage = "localidades1.jpg"
                },
                new DetailEvent
                {
                    EventName = "Obra de Teatro 'Hamlet'",
                    EventImage = "hamlet.jpg",
                    EventDate = DateTime.Now.AddMonths(1),
                    EventLocation = "Teatro Real, Madrid",
                    EventDescription = "Una interpretación moderna del clásico de Shakespeare.",
                    Category = "Teatro",
                    LocalidadesImage = "localidades2.jpg"
                },
                new DetailEvent
                {
                    EventName = "Musical 'El Rey León'",
                    EventImage = "rey_leon.jpg",
                    EventDate = DateTime.Now.AddMonths(2),
                    EventLocation = "Teatro Lope de Vega, Madrid",
                    EventDescription = "Disfruta del famoso musical con impresionantes escenografías y música inolvidable.",
                    Category = "Teatro",
                    LocalidadesImage = "localidades2.jpg"
                }
            };
        }

        private void UpdateCategories()
        {
            TicketCategories = new ObservableCollection<string>();

            if (SelectedEvent == null)
                return;

            switch (SelectedEvent.Category)
            {
                case "Conciertos":
                    TicketCategories.Add("TOP BOX - $80");
                    TicketCategories.Add("GOLDEN BOX - $70");
                    TicketCategories.Add("BUTACAS - $50");
                    TicketCategories.Add("PREFERENCIAS - $60");
                    TicketCategories.Add("GENERAL FRONTAL - $40");
                    break;
                case "Teatro":
                    TicketCategories.Add("LIVE TABLE - $100");
                    TicketCategories.Add("MESAS VIP - $90");
                    TicketCategories.Add("MESAS PREMIUM - $80");
                    TicketCategories.Add("MESAS - $70");
                    TicketCategories.Add("TRIBUNA - $60");
                    TicketCategories.Add("PALCO VIP - $50");
                    break;
                case "Deportes":
                    TicketCategories.Add("PALCO - $100");
                    TicketCategories.Add("TRIBUNA-N - $90");
                    TicketCategories.Add("TRIBUNA-S - $90");
                    TicketCategories.Add("PREFERENCIAL - $70");
                    TicketCategories.Add("GENERAL-N - $50");
                    TicketCategories.Add("GENERAL-S - $50");
                    break;
            }

            OnPropertyChanged(nameof(TicketCategories));
        }

        private void CalculateTotalAmount()
        {
            if (int.TryParse(TicketQuantity, out int quantity) && !string.IsNullOrWhiteSpace(SelectedCategory))
            {
                var priceString = SelectedCategory.Split('-').Last().Trim().TrimStart('$');
                if (double.TryParse(priceString, out double price))
                {
                    TotalAmount = quantity * price;
                }
            }
            else
            {
                TotalAmount = 0;
            }
        }

        private async void OnConfirmPurchase()
        {
            // Lógica de compra de tickets
            int purchaseId = await _servicioCompra.SavePurchaseAsync(HolderName, HolderId, int.Parse(TicketQuantity), SelectedCategory, (decimal)TotalAmount, SelectedEvent.EventName, SelectedEvent.EventLocation, SelectedEvent.EventDate);
            await Application.Current.MainPage.DisplayAlert("Compra Exitosa", $"Has comprado {TicketQuantity} tickets por un total de ${TotalAmount}. Número de orden: {purchaseId}", "OK");

            // Limpiar los campos
            TicketQuantity = string.Empty;
            CardName = string.Empty;
            CardNumber = string.Empty;
            CardExpiry = string.Empty;
            CardCVC = string.Empty;
            SelectedEvent = null;
            SelectedCategory = null;
            HolderName = string.Empty;
            HolderId = string.Empty;
            TotalAmount = 0;


        }
    }
}
