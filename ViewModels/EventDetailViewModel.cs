using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class EventDetailViewModel : BindableObject
    {
        public ObservableCollection<DetailEvent> Events { get; set; }
        public ICommand ShareEventCommand { get; }

        public EventDetailViewModel()
        {
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

            ShareEventCommand = new Command(async () => await OnShareEventAsync());
        }

        private async Task OnShareEventAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Compartir", "Evento compartido exitosamente.", "OK");
        }
    }
}
