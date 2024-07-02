using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace InterfazTicketsApp.Services
{
    public class ServicioCompra
    {
        private readonly string _connectionString;

        public ServicioCompra(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> SavePurchaseAsync(string holderName, string holderId, int ticketQuantity, string ticketCategory, decimal totalAmount, string eventName, string eventLocation, DateTime eventDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO Purchases (HolderName, HolderId, TicketQuantity, TicketCategory, TotalAmount, EventName, EventLocation, EventDate)
                              VALUES (@HolderName, @HolderId, @TicketQuantity, @TicketCategory, @TotalAmount, @EventName, @EventLocation, @EventDate);
                              SELECT CAST(SCOPE_IDENTITY() as int)";

                var parameters = new
                {
                    HolderName = holderName,
                    HolderId = holderId,
                    TicketQuantity = ticketQuantity,
                    TicketCategory = ticketCategory,
                    TotalAmount = totalAmount,
                    EventName = eventName,
                    EventLocation = eventLocation,
                    EventDate = eventDate
                };

                await connection.OpenAsync();
                var purchaseId = await connection.ExecuteScalarAsync<int>(query, parameters);
                return purchaseId;
            }
        }

        public async Task<string> GetOrderDetailsAsync(int orderId, string identificationNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM Purchases WHERE PurchaseId = @OrderId AND HolderId = @IdentificationNumber";
                var parameters = new { OrderId = orderId, IdentificationNumber = identificationNumber };

                var order = await connection.QuerySingleOrDefaultAsync(query, parameters);

                if (order != null)
                {
                    return $"ID de Orden: {order.PurchaseId}\n" +
                           $"Nombre del Titular: {order.HolderName}\n" +
                           $"ID del Titular: {order.HolderId}\n" +
                           $"Cantidad de Tickets: {order.TicketQuantity}\n" +
                           $"Categoría de Tickets: {order.TicketCategory}\n" +
                           $"Monto Total: {order.TotalAmount}\n" +
                           $"Nombre del Evento: {order.EventName}\n" +
                           $"Ubicación del Evento: {order.EventLocation}\n" +
                           $"Fecha del Evento: {order.EventDate:dd/MM/yyyy}";
                }

                return null;
            }
        }
        public async Task<string> GetUserNameByIdAsync(string identificationNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT HolderName FROM Purchases WHERE HolderId = @IdentificationNumber";
                var parameters = new { IdentificationNumber = identificationNumber };

                return await connection.QuerySingleOrDefaultAsync<string>(query, parameters);
            }
        }


    }
}

