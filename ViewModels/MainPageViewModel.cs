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
        private DateTime _selectedDate;
        private ObservableCollection<Event> _allEvents;

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }
        public ObservableCollection<Event> Events { get; }

        public MainPageViewModel()
        {
            _allEvents = new ObservableCollection<Event>
            {
                new Event
                {
                    EventName = "Concierto de Rock",
                    EventDate = DateTime.Now.AddMonths(1)
                },
                new Event
                {
                    EventName = "Festival de Jazz",
                    EventDate = DateTime.Now.AddMonths(2)
                }
            };

            Events = new ObservableCollection<Event>(_allEvents);

            SearchCommand = new Command(OnSearch);
        }

        private void OnSearch()
        {
            var filteredEvents = _allEvents.Where(e =>
                (string.IsNullOrEmpty(SearchQuery) || e.EventName.ToLower().Contains(SearchQuery.ToLower())) &&
                (string.IsNullOrEmpty(SelectedCategory) || e.EventName.ToLower().Contains(SelectedCategory.ToLower())) &&
                (SelectedDate == default || e.EventDate.Date == SelectedDate.Date)
            ).ToList();

            Events.Clear();
            foreach (var ev in filteredEvents)
            {
                Events.Add(ev);
            }
        }
    }
}
