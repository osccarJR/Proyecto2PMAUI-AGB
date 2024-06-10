using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class CommentsViewModel : BindableObject
    {
        public ObservableCollection<Comment> Comments { get; set; }
        private string _newComment;
        public string NewComment
        {
            get => _newComment;
            set
            {
                _newComment = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommentCommand { get; set; }
        public ICommand LoadCommentsCommand { get; set; }
        public ICommand SaveCommentsCommand { get; set; }

        public CommentsViewModel()
        {
            Comments = new ObservableCollection<Comment>
            {
                new Comment { UserName = "Juan Pérez", CommentText = "¡Excelente evento!" },
                new Comment { UserName = "María Gómez", CommentText = "Me encantó la organización." }
            };

            SubmitCommentCommand = new Command(OnSubmitComment);
            LoadCommentsCommand = new Command(async () => await LoadCommentsAsync());
            SaveCommentsCommand = new Command(async () => await SaveCommentsAsync());
        }

        private void OnSubmitComment()
        {
            if (!string.IsNullOrWhiteSpace(NewComment))
            {
                Comments.Add(new Comment { UserName = "Usuario Actual", CommentText = NewComment });
                NewComment = string.Empty;
            }
        }

        private async Task LoadCommentsAsync()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    using (var stream = await result.OpenReadAsync())
                    using (var reader = new StreamReader(stream))
                    {
                        var fileContent = await reader.ReadToEndAsync();
                        var comments = fileContent.Split('\n');
                        Comments.Clear();
                        foreach (var comment in comments)
                        {
                            if (!string.IsNullOrWhiteSpace(comment))
                            {
                                Comments.Add(new Comment { UserName = "Usuario", CommentText = comment });
                            }
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
            try
            {
                string fileName = Path.Combine(FileSystem.CacheDirectory, "comments.txt");
                using (var stream = File.Create(fileName))
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var comment in Comments)
                    {
                        await writer.WriteLineAsync(comment.CommentText);
                    }
                }

                await Application.Current.MainPage.DisplayAlert("Guardado", "Comentarios guardados exitosamente.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al guardar comentarios: {ex.Message}", "OK");
            }
        }
    }
}
