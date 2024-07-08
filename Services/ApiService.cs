using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using InterfazTicketsApp.Models;
using Newtonsoft.Json;

namespace InterfazTicketsApp.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5168"); // URL base de la API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetUserNameByIdAsync(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonString);
                return user?.UserName;
            }
            return null;
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/comments");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Comment>>(jsonString);
            }
            return new List<Comment>();
        }

        public async Task SaveCommentsAsync(List<Comment> comments)
        {
            var jsonString = JsonConvert.SerializeObject(comments);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/api/comments", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> SavePurchaseAsync(string holderName, string holderId, int ticketQuantity, string selectedCategory, decimal totalAmount, string eventName, string eventLocation, DateTime eventDate)
        {
            var purchase = new Purchase
            {
                HolderName = holderName,
                HolderId = holderId,
                TicketQuantity = ticketQuantity,
                SelectedCategory = selectedCategory,
                TotalAmount = totalAmount,
                EventName = eventName,
                EventLocation = eventLocation,
                EventDate = eventDate
            };

            var jsonString = JsonConvert.SerializeObject(purchase);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/api/purchases", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(responseString); // Asumiendo que la API devuelve el ID de la compra como int
        }

        public async Task<string> GetOrderDetailsAsync(int orderNumber, string identificationNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/orders/{orderNumber}/{identificationNumber}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
