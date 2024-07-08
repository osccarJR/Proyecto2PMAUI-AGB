using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private string _searchQuery;
        private string _selectedCategory;
        private DateTime _selectedDate = DateTime.Now;
        private ObservableCollection<DetailEvent> _allEvents;
        private DetailEvent _selectedEvent;

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                OnSearch();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                OnSearch();
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                OnSearch();
            }
        }

        public DetailEvent SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
                if (_selectedEvent != null)
                {
                    NavigateToDetails(_selectedEvent);
                }
            }
        }

        public ObservableCollection<DetailEvent> Events { get; }

        public MainPageViewModel()
        {
            _allEvents = new ObservableCollection<DetailEvent>
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
                    EventImage = "rey_leon.jpeg",
                    EventDate = DateTime.Now.AddMonths(2),
                    EventLocation = "Teatro Lope de Vega, Madrid",
                    EventDescription = "Disfruta del famoso musical con impresionantes escenografías y música inolvidable.",
                    Category = "Teatro",
                    LocalidadesImage = "localidades2.jpg"
                }
            };

            Events = new ObservableCollection<DetailEvent>(_allEvents);

            OnSearch();
        }

        private void OnSearch()
        {
            var filteredEvents = _allEvents.Where(e =>
                (string.IsNullOrEmpty(SearchQuery) || e.EventName.ToLower().Contains(SearchQuery.ToLower())) &&
                (SelectedCategory == "Ver Todos" || string.IsNullOrEmpty(SelectedCategory) || e.Category == SelectedCategory)
            ).ToList();

            Events.Clear();
            foreach (var ev in filteredEvents)
            {
                Events.Add(ev);
            }
        }

        public async void NavigateToDetails(DetailEvent selectedEvent)
        {
            // Navegar a la página de detalles pasando parámetros
            await Shell.Current.GoToAsync($"///Detalles?eventName={selectedEvent.EventName}&eventDescription={selectedEvent.EventDescription}&eventImage={selectedEvent.EventImage}&eventLocation={selectedEvent.EventLocation}&eventDate={selectedEvent.EventDate}&localidadesImage={selectedEvent.LocalidadesImage}");
        }
    }
}

