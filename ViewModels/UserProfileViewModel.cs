using System.Windows.Input;
using InterfazTicketsApp.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace InterfazTicketsApp.ViewModels
{
    public class UserProfileViewModel : BindableObject
    {
        private readonly IApiService _apiService;
        private string _orderNumber;
        private string _identificationNumber;
        private string _orderDetails;
        private bool _isOrderDetailsVisible;

        public string OrderNumber
        {
            get => _orderNumber;
            set
            {
                if (_orderNumber != value)
                {
                    _orderNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string IdentificationNumber
        {
            get => _identificationNumber;
            set
            {
                if (_identificationNumber != value)
                {
                    _identificationNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string OrderDetails
        {
            get => _orderDetails;
            private set
            {
                if (_orderDetails != value)
                {
                    _orderDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsOrderDetailsVisible
        {
            get => _isOrderDetailsVisible;
            private set
            {
                if (_isOrderDetailsVisible != value)
                {
                    _isOrderDetailsVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand FetchOrderDetailsCommand { get; }

        public UserProfileViewModel()
        {
            // Constructor sin parámetros necesario para la instanciación desde XAML
        }

        public UserProfileViewModel(IApiService apiService)
        {
            _apiService = apiService;
            FetchOrderDetailsCommand = new Command(async () => await FetchOrderDetailsAsync());
        }

        private async Task FetchOrderDetailsAsync()
        {
            if (string.IsNullOrWhiteSpace(OrderNumber) || string.IsNullOrWhiteSpace(IdentificationNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese ambos el número de orden y el número de identificación.", "OK");
                return;
            }

            var orderDetails = await _apiService.GetOrderDetailsAsync(int.Parse(OrderNumber), IdentificationNumber);
            if (orderDetails != null)
            {
                OrderDetails = orderDetails;
                IsOrderDetailsVisible = true;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se encontraron detalles para la orden proporcionada.", "OK");
                IsOrderDetailsVisible = false;
            }

            OrderNumber = string.Empty;
            IdentificationNumber = string.Empty;
        }
    }
}
