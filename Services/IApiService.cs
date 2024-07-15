using System.Collections.Generic;
using System.Threading.Tasks;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.Services
{
    public interface IApiService
    {
        Task<IEnumerable<EventoDetalle>> GetDetailEventsAsync();
        Task<IEnumerable<Compra>> GetPurchasesAsync();
        Task PostPurchaseAsync(Compra purchase);
    }
}
