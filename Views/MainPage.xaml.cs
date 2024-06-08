
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace InterfazTicketsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(); 
        }
    }

    public class MainPageViewModel
    {
        public string SearchQuery { get; set; }
        public string SelectedCategory { get; set; }
        public DateTime SelectedDate { get; set; }
        public Command SearchCommand { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        public MainPageViewModel()
        {
            // Inicializa las propiedades y el comando
            SearchCommand = new Command(OnSearch);
            Events = new ObservableCollection<Event>();
        }

        private void OnSearch()
        {
            // Lógica para la búsqueda de eventos
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
