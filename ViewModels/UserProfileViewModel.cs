using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.ViewModels
{
    public class UserProfileViewModel : BindableObject
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public ICommand SaveProfileCommand { get; set; }

        public UserProfileViewModel()
        {
            SaveProfileCommand = new Command(OnSaveProfile);
        }

        private void OnSaveProfile()
        {
            // Handle save profile logic here
        }
    }
}
