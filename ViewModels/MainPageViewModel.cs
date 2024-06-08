using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public string SearchQuery { get; set; }
        public string SelectedCategory { get; set; }
        public DateTime SelectedDate { get; set; }
        public ICommand SearchCommand { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        public MainPageViewModel()
        {
            SearchCommand = new Command(OnSearch);
            Events = new ObservableCollection<Event>();
        }

        private void OnSearch()
        {
            // Logic for searching events
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
