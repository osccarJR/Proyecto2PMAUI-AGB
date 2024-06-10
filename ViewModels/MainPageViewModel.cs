using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public string SearchQuery { get; set; }
        public string SelectedCategory { get; set; }
        public DateTime SelectedDate { get; set; }
        public ICommand SearchCommand { get; }
        public ObservableCollection<Event> Events { get; }

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
}
