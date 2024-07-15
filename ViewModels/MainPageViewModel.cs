using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private readonly IApiService _apiService;
        private string _searchQuery;
        private ObservableCollection<EventoDetalle> _allEvents;
        private EventoDetalle _selectedEvent;

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

        public EventoDetalle SelectedEvent
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

        public ObservableCollection<EventoDetalle> Events { get; }

        public MainPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            Events = new ObservableCollection<EventoDetalle>();
            LoadEvents();
        }

        private async void LoadEvents()
        {
            var events = await _apiService.GetDetailEventsAsync();
            _allEvents = new ObservableCollection<EventoDetalle>(events);
            OnSearch();
        }

        private void OnSearch()
        {
            var filteredEvents = _allEvents.Where(e =>
                string.IsNullOrEmpty(SearchQuery) || e.EventName.ToLower().Contains(SearchQuery.ToLower())
            ).ToList();

            Events.Clear();
            foreach (var ev in filteredEvents)
            {
                Events.Add(ev);
            }
        }


        public async void NavigateToDetails(EventoDetalle selectedEvent)
        {
            var route = $"///Detalles?eventName={selectedEvent.EventName}&eventDescription={selectedEvent.EventDescription}&eventImage={selectedEvent.EventImage}&eventLocation={selectedEvent.EventLocation}&eventDate={selectedEvent.EventDate:yyyy-MM-dd}&ticketPrice={selectedEvent.TicketPrice}";
            await Shell.Current.GoToAsync(route);
        }

    }
}
