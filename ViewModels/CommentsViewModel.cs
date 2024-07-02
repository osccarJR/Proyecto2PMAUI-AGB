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
        private readonly ServicioCompra _servicioCompra;
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

        public CommentsViewModel()
        {
            _servicioCompra = App.ServicioCompra;
            Comments = new ObservableCollection<Comment>();

            SubmitCommentCommand = new Command(async () => await OnSubmitCommentAsync());
            LoadCommentsCommand = new Command(async () => await LoadCommentsAsync());
            SaveCommentsCommand = new Command(async () => await SaveCommentsAsync());

            // Cargar comentarios al iniciar
            Task.Run(async () => await LoadCommentsAsync());
        }

        private async Task OnSubmitCommentAsync()
        {
            if (string.IsNullOrWhiteSpace(IdentificationNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese su número de identificación.", "OK");
                return;
            }

            _userName = await _servicioCompra.GetUserNameByIdAsync(IdentificationNumber);

            if (_userName == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se encontró un usuario con ese número de identificación.", "OK");
                return;
            }

            if (!string.IsNullOrWhiteSpace(NewComment))
            {
                var comment = new Comment { UserName = _userName, CommentText = NewComment };
                Comments.Add(comment);
                await SaveCommentsAsync();
                NewComment = string.Empty;
                IdentificationNumber = string.Empty;
            }
        }

        private async Task LoadCommentsAsync()
        {
            // Lógica para cargar comentarios desde almacenamiento (puede ser un archivo o base de datos)
            // Ejemplo: leer desde un archivo de texto
            try
            {
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "comments.txt");
                if (File.Exists(filePath))
                {
                    var lines = await File.ReadAllLinesAsync(filePath);
                    Comments.Clear();
                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            Comments.Add(new Comment { UserName = parts[0], CommentText = parts[1] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al cargar comentarios: {ex.Message}", "OK");
            }
        }

        private async Task SaveCommentsAsync()
        {
            // Lógica para guardar comentarios en almacenamiento (puede ser un archivo o base de datos)
            // Ejemplo: escribir en un archivo de texto
            try
            {
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "comments.txt");
                var lines = new List<string>();
                foreach (var comment in Comments)
                {
                    lines.Add($"{comment.UserName}|{comment.CommentText}");
                }
                await File.WriteAllLinesAsync(filePath, lines);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al guardar comentarios: {ex.Message}", "OK");
            }
        }
    }
}

