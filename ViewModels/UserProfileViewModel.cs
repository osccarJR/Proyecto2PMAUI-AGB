using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class UserProfileViewModel : BindableObject
    {
        private string _userName;
        private string _userEmail;
        private string _userPhone;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserEmail
        {
            get => _userEmail;
            set
            {
                if (_userEmail != value)
                {
                    _userEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserPhone
        {
            get => _userPhone;
            set
            {
                if (_userPhone != value)
                {
                    _userPhone = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveProfileCommand { get; }

        public UserProfileViewModel()
        {
            SaveProfileCommand = new Command(OnSaveProfile);
        }

        private void OnSaveProfile()
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserEmail) || string.IsNullOrWhiteSpace(UserPhone))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Simular guardado de perfil
            Application.Current.MainPage.DisplayAlert("Perfil Guardado", "¡Los cambios han sido guardados exitosamente!", "OK");
        }
    }
}
