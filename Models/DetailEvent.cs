namespace InterfazTicketsApp.Models
{
    public class DetailEvent
    {
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public string Category { get; set; } // Nueva propiedad para la categoría del evento
        public string LocalidadesImage { get; set; } // Nueva propiedad para la imagen de las localidades
    }
}

