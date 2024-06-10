﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class EventDetailViewModel : BindableObject
    {
        private readonly DetaiilEvent _event;

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
            try
            {
                await Task.Delay(2000); // Simular una espera asincrónica para la compra de tickets
                await Application.Current.MainPage.DisplayAlert("Compra Exitosa", "¡Has comprado tus tickets exitosamente!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al comprar tickets: {ex.Message}", "OK");
            }
        }

        private async Task OnShareEventAsync()
        {
            try
            {
                await Task.Delay(1000); // Simular una espera asincrónica para compartir el evento
                await Application.Current.MainPage.DisplayAlert("Compartir", "Evento compartido exitosamente.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al compartir el evento: {ex.Message}", "OK");
            }
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
