using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models; // Asegúrate de incluir el espacio de nombres de tus modelos

namespace InterfazTicketsApp.ViewModels
{
    public class EventDetailViewModel : BindableObject
    {
        private DetaiilEvent _event;

        public EventDetailViewModel()
        {
            _event = new DetaiilEvent
            {
                EventName = "Concierto de Rock",
                EventImage = "rock.jpg",
                EventDate = DateTime.Now.AddMonths(1),
                EventLocation = "Teatro Nacional, Madrid",
                EventDescription = "Disfruta de una noche mágica con la mejor música rock interpretada por Van Halen."
            };

            BuyTicketsCommand = new Command(async () => await OnBuyTicketsAsync());
            ShareEventCommand = new Command(async () => await OnShareEventAsync());
        }

        public string EventName => _event.EventName;
        public string EventImage => _event.EventImage;
        public DateTime EventDate => _event.EventDate;
        public string EventLocation => _event.EventLocation;
        public string EventDescription => _event.EventDescription;

        public ICommand BuyTicketsCommand { get; }
        public ICommand ShareEventCommand { get; }

        private async Task OnBuyTicketsAsync()
        {
            await Task.Delay(2000); // Simular una espera asincrónica para la compra de tickets
            // Lógica para comprar tickets
        }

        private async Task OnShareEventAsync()
        {
            await Task.Delay(1000); // Simular una espera asincrónica para compartir el evento
            // Lógica para compartir el evento
        }
    }

    public class DetaiilEvent
    {
        public string EventName { get; set; }
        public string EventImage { get; set; } // Path to the image
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
    }
}
