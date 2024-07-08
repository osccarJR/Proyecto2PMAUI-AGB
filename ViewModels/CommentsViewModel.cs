using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Models;
using InterfazTicketsApp.Services;

namespace InterfazTicketsApp.ViewModels
{
    public class CommentsViewModel : BindableObject
    {
        private readonly IApiService _apiService;
        private string _newComment;
        private string _identificationNumber;
        private string _userName;

        public ObservableCollection<Comment> Comments { get; set; }

        public string NewComment
        {
            get => _newComment;
            set
            {
                _newComment = value;
                OnPropertyChanged();
            }
        }

        public string IdentificationNumber
        {
            get => _identificationNumber;
            set
            {
                _identificationNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommentCommand { get; set; }
        public ICommand LoadCommentsCommand { get; set; }
        public ICommand SaveCommentsCommand { get; set; }

        public CommentsViewModel(IApiService apiService)
        {
            _apiService = apiService;
            Comments = new ObservableCollection<Comment>();

            SubmitCommentCommand = new Command(async () => await OnSubmitCommentAsync());
            LoadCommentsCommand = new Command(async () => await LoadCommentsAsync());
            SaveCommentsCommand = new Command(async () => await SaveCommentsAsync());

            // Cargar comentarios al iniciar
            Task.Run(async () => await LoadCommentsAsync());
        }

        private async Task OnSubmitCommentAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(IdentificationNumber))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese su número de identificación.", "OK");
                    return;
                }

                var userName = await _apiService.GetUserNameByIdAsync(IdentificationNumber);

                if (userName == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se encontró un usuario con ese número de identificación.", "OK");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(NewComment))
                {
                    var comment = new Comment { UserName = userName, CommentText = NewComment };
                    Comments.Add(comment);
                    await SaveCommentsAsync();
                    NewComment = string.Empty;
                    IdentificationNumber = string.Empty;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al enviar el comentario: {ex.Message}", "OK");
            }
        }

        private async Task LoadCommentsAsync()
        {
            try
            {
                var comments = await _apiService.GetCommentsAsync();
                Comments.Clear();
                foreach (var comment in comments)
                {
                    Comments.Add(comment);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al cargar comentarios: {ex.Message}", "OK");
            }
        }

        private async Task SaveCommentsAsync()
        {
            try
            {
                await _apiService.SaveCommentsAsync(new List<Comment>(Comments));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al guardar comentarios: {ex.Message}", "OK");
            }
        }
    }
}
