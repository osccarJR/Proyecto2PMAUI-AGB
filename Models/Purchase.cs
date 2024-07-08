namespace InterfazTicketsApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string HolderName { get; set; }
        public string HolderId { get; set; }
        public int TicketQuantity { get; set; }
        public string SelectedCategory { get; set; }
        public decimal TotalAmount { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventDate { get; set; }
    }
}
