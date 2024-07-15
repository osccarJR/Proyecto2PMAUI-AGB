using Microsoft.Maui.Controls;
using InterfazTicketsApp.ViewModels;
using System;

namespace InterfazTicketsApp.Views
{
    [QueryProperty(nameof(EventName), "eventName")]
    [QueryProperty(nameof(EventDescription), "eventDescription")]
    [QueryProperty(nameof(EventImage), "eventImage")]
    [QueryProperty(nameof(EventLocation), "eventLocation")]
    [QueryProperty(nameof(EventDate), "eventDate")]
    [QueryProperty(nameof(TicketPrice), "ticketPrice")]
    public partial class EventoDetallePage : ContentPage
    {
        public string EventName
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && !string.IsNullOrEmpty(value))
                {
                    viewModel.EventName = value;
                }
            }
        }

        public string EventDescription
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && !string.IsNullOrEmpty(value))
                {
                    viewModel.EventDescription = value;
                }
            }
        }

        public string EventImage
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && !string.IsNullOrEmpty(value))
                {
                    viewModel.EventImage = value;
                }
            }
        }

        public string EventLocation
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && !string.IsNullOrEmpty(value))
                {
                    viewModel.EventLocation = value;
                }
            }
        }

        public string EventDate
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && DateTime.TryParse(value, out DateTime date))
                {
                    viewModel.EventDate = date;
                }
            }
        }

        public string TicketPrice
        {
            set
            {
                var viewModel = BindingContext as EventoDetalleViewModel;
                if (viewModel != null && decimal.TryParse(value, out decimal price))
                {
                    viewModel.TicketPrice = price;
                }
            }
        }

        public EventoDetallePage()
        {
            InitializeComponent();
            BindingContext = new EventoDetalleViewModel();
        }
    }
}
