using System.Collections.Generic;
using System.Threading.Tasks;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.Services
{
    public interface IApiService
    {
        Task<string> GetUserNameByIdAsync(string id);
        Task<List<Comment>> GetCommentsAsync();
        Task SaveCommentsAsync(List<Comment> comments);
        Task<int> SavePurchaseAsync(string holderName, string holderId, int ticketQuantity, string selectedCategory, decimal totalAmount, string eventName, string eventLocation, DateTime eventDate);
        Task<string> GetOrderDetailsAsync(int orderNumber, string identificationNumber);
    }
}
