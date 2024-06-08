using Microsoft.Maui.Controls;
using System;

namespace InterfazTicketsApp
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            BindingContext = this;
            // Inicializar con datos de ejemplo
            UserName = "Juan Perez";
            UserEmail = "juan.perez@hotmail.com";
            UserPhone = "0962714697";
        }

        // Propiedades enlazadas a los controles
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        private async void OnSaveProfile(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserEmail) || string.IsNullOrWhiteSpace(UserPhone))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Simular guardado de perfil
            await DisplayAlert("Perfil Guardado", "¡Los cambios han sido guardados exitosamente!", "OK");
        }
    }
}
